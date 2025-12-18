using AutoMapper;
using Airline.Application.Contracts.Protos;
using Grpc.Core;
using Airline.Generator.Grpc.Host.Generator;

namespace Airline.Generator.Grpc.Host.Grpc;

/// <summary>
/// Имплементация gRPC серверной части службы для генерации и отправки батчей билетов
/// </summary>
/// <param name="configuration">Конфигурация</param>
/// <param name="mapper">Профиль маппинга</param>
/// <param name="logger">Логгер</param>
public sealed class AirlineGrpcGeneratorService(
    IConfiguration configuration,
    IMapper mapper,
    ILogger<AirlineGrpcGeneratorService> logger
) : TicketGeneratorGrpcService.TicketGeneratorGrpcServiceBase
{
    private readonly string _defaultBatchSize =
        configuration.GetSection("Generator")["BatchSize"] ?? throw new KeyNotFoundException("BatchSize section of Generator is missing");

    private readonly string _waitTime =
        configuration.GetSection("Generator")["WaitTime"] ?? throw new KeyNotFoundException("WaitTime section of Generator is missing");

    /// <summary>
    /// Служба bidirectional стриминга которая принимает запросы генерации и отправляет батчи контрактов клиенту
    /// </summary>
    /// <param name="requestStream">Клиентский стрим запросов</param>
    /// <param name="responseStream">Серверный стрим ответов</param>
    /// <param name="context">Контекст вызова</param>
    /// <exception cref="FormatException">Если параметры конфигурации не парсятся</exception>
    public override async Task TicketStream(
        IAsyncStreamReader<TicketGenerationRequest> requestStream,
        IServerStreamWriter<TicketBatchStreamMessage> responseStream,
        ServerCallContext context)
    {
        if (!int.TryParse(_defaultBatchSize, out var defaultBatchSize))
            throw new FormatException("Unable to parse Generator:BatchSize");

        if (!int.TryParse(_waitTime, out var waitTimeSeconds))
            throw new FormatException("Unable to parse Generator:WaitTime");

        logger.LogInformation("Ticket generator stream started peer={peer} defaultBatchSize={batch} waitTimeSec={wait}", context.Peer, defaultBatchSize, waitTimeSeconds);

        await foreach (var req in requestStream.ReadAllAsync(context.CancellationToken))
        {
            if (context.CancellationToken.IsCancellationRequested)
                break;

            var requestId = req.RequestId ?? string.Empty;

            if (req.Count <= 0)
            {
                logger.LogWarning("Skipping request with non positive count requestId={requestId} count={count}", requestId, req.Count);
                continue;
            }

            var batchSize = req.BatchSize > 0 ? req.BatchSize : defaultBatchSize;

            logger.LogInformation("Processing request requestId={requestId} count={count} batchSize={batchSize}", requestId, req.Count, batchSize);

            var sent = 0;

            while (sent < req.Count && !context.CancellationToken.IsCancellationRequested)
            {
                try
                {
                    var take = Math.Min(batchSize, req.Count - sent);

                    var dtos = TicketGenerator.Generate(take);

                    var payload = new TicketBatchStreamMessage
                    {
                        RequestId = requestId,
                        IsFinal = false
                    };

                    payload.Tickets.AddRange(mapper.Map<IList<TicketCreateUpdateDtoMessage>>(dtos));

                    sent += take;
                    payload.IsFinal = sent >= req.Count;

                    await responseStream.WriteAsync(payload);

                    logger.LogInformation("Sent batch requestId={requestId} batch={batch} sent={sent} total={total} isFinal={isFinal}", requestId, take, sent, req.Count, payload.IsFinal);

                    if (payload.IsFinal)
                        break;

                    if (waitTimeSeconds > 0)
                        await Task.Delay(waitTimeSeconds * 1000, context.CancellationToken);
                }
                catch (TaskCanceledException ex)
                {
                    logger.LogWarning(ex, "Cancellation requested from client peer={peer} requestId={requestId}", context.Peer, requestId);
                    return;
                }
            }
        }

        logger.LogInformation("Ticket generator stream finished peer={peer}", context.Peer);
    }
}