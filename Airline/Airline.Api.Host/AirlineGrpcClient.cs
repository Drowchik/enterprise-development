using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;
using Airline.Application.Contracts.Protos;
using Airline.Application.Contracts.Tickets;
using AutoMapper;
using Grpc.Core;
using System.Collections.Concurrent;

namespace Airline.Api.Host;

/// <summary>
/// Фоновый gRPC клиент для получения батчей TicketCreateUpdateDto из bidirectional стрима и создания билетов в системе
/// </summary>
public class AirlineGrpcClient(
    TicketGeneratorGrpcService.TicketGeneratorGrpcServiceClient client,
    IServiceScopeFactory scopeFactory,
    IMapper mapper,
    ILogger<AirlineGrpcClient> logger,
    IConfiguration cfg
) : BackgroundService
{
    private readonly ConcurrentDictionary<int, bool> _flightExists = [];
    private readonly ConcurrentDictionary<int, bool> _passengerExists = [];

    /// <summary>
    /// Основной цикл фонового сервиса который подключается к gRPC серверу отправляет запрос генерации и обрабатывает входящие батчи
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var countPerRequest = cfg.GetValue("TicketGenerator:CountPerRequest", 100);
                var batchSize = cfg.GetValue("TicketGenerator:BatchSize", 10);

                logger.LogInformation("Connecting to TicketGenerator gRPC bidirectional stream...");

                using var call = client.TicketStream(cancellationToken: stoppingToken);

                var requestId = Guid.NewGuid().ToString("N");

                var writerTask = Task.Run(async () =>
                {
                    await call.RequestStream.WriteAsync(new TicketGenerationRequest
                    {
                        RequestId = requestId,
                        Count = countPerRequest,
                        BatchSize = batchSize
                    });

                    await call.RequestStream.CompleteAsync();
                }, stoppingToken);

                await foreach (var msg in call.ResponseStream.ReadAllAsync(stoppingToken))
                {
                    if (!string.Equals(msg.RequestId, requestId, StringComparison.Ordinal))
                        continue;

                    var dtos = msg.Tickets.Select(mapper.Map<TicketCreateUpdateDto>).ToList();

                    using var scope = scopeFactory.CreateScope();

                    var ticketService = scope.ServiceProvider.GetRequiredService<ITicketService>();
                    var flightRepo = scope.ServiceProvider.GetRequiredService<IFlightService>();
                    var passengerRepo = scope.ServiceProvider.GetRequiredService<IPassengerService>();

                    var valid = new List<TicketCreateUpdateDto>(dtos.Count);

                    foreach (var dto in dtos)
                    {
                        if (!await ExistsAsync(dto.FlightId, _flightExists, flightRepo.Get, stoppingToken))
                        {
                            logger.LogWarning("Skipping ticket dto because flight with id {flightId} was not found passengerId={passengerId}", dto.FlightId, dto.PassengerId);
                            continue;
                        }

                        if (!await ExistsAsync(dto.PassengerId, _passengerExists, passengerRepo.Get, stoppingToken))
                        {
                            logger.LogWarning("Skipping ticket dto because passenger with id {passengerId} was not found flightId={flightId}", dto.PassengerId, dto.FlightId);
                            continue;
                        }

                        valid.Add(dto);
                    }

                    var created = 0;
                    foreach (var dto in valid)
                    {
                        await ticketService.Create(dto);
                        created++;
                    }

                    logger.LogInformation("Received batch: total={total}, valid={valid}, created={created}, isFinal={isFinal}", dtos.Count, valid.Count, created, msg.IsFinal);

                    if (msg.IsFinal)
                        break;
                }

                await writerTask;

                logger.LogInformation("Finished receiving tickets for request_id={requestId}", requestId);
                break;
            }
            catch (RpcException ex) when (!stoppingToken.IsCancellationRequested)
            {
                logger.LogError(ex, "gRPC stream error: {code} - {status}", ex.StatusCode, ex.Status);
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
            catch (Exception ex) when (!stoppingToken.IsCancellationRequested)
            {
                logger.LogError(ex, "Unexpected exception during receiving tickets from gRPC stream");
                break;
            }
        }
    }

    /// <summary>
    /// Проверка наличия сущности по идентификатору с использованием кэша чтобы не выполнять повторные запросы
    /// </summary>
    private static async Task<bool> ExistsAsync<TEntity>(int id, ConcurrentDictionary<int, bool> cache, Func<int, Task<TEntity?>> readFunc, CancellationToken ct)
        where TEntity : class
    {
        if (cache.TryGetValue(id, out var cached))
            return cached;

        ct.ThrowIfCancellationRequested();
        var entity = await readFunc(id);
        var ok = entity is not null;

        cache.TryAdd(id, ok);
        return ok;
    }
}