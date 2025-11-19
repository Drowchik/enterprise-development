using Airline.Application.Contracts.AircraftModels;
using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;
using Airline.Application.Contracts.Tickets;
using Airline.Domain;
using Airline.Domain.Model.AircraftModels;
using Airline.Domain.Model.Flights;
using Airline.Domain.Model.Passengers;
using Airline.Domain.Model.Tickets;
using AutoMapper;

namespace Airline.Application.Services;

/// <summary>
/// Сервис для управления рейсами и получения связанных моделей
/// </summary>
/// <param name="flightRepository">Репозиторий для операций с сущностями рейсов</param>
/// <param name="modelRepository">Репозиторий для операций с сущностями моделей самолётов</param>
/// <param name="ticketRepository">Репозиторий для операций с сущностями билетов</param>
/// <param name="passengerRepository">Репозиторий для операций с сущностями пассажиров</param>
/// <param name="mapper">Маппер для преобразования доменных моделей в DTO и обратно</param>
public class FlightService(
    IRepository<Flight, int> flightRepository,
    IRepository<AircraftModel, int> modelRepository,
    IRepository<Ticket, int> ticketRepository,
    IRepository<Passenger, int> passengerRepository,
    IMapper mapper
) : IFlightService
{
    /// <inheritdoc/>
    public async Task<FlightDto> Create(FlightCreateUpdateDto dto)
    {
        var entity = mapper.Map<Flight>(dto);

        var last = await flightRepository.ReadAll();
        entity.Id = last.Any() ? last.Max(x => x.Id) + 1 : 1;

        var result = await flightRepository.Create(entity);

        return mapper.Map<FlightDto>(result);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int dtoId) =>
        await flightRepository.Delete(dtoId);

    /// <inheritdoc/>
    public async Task<FlightDto?> Get(int dtoId)
    {
        var entity = await flightRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        return mapper.Map<FlightDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<AircraftModelDto> GetAircraftModel(int flightId)
    {
        var flight = await flightRepository.Read(flightId) ?? throw new KeyNotFoundException($"Flight with Id {flightId} not found");

        var model = await modelRepository.Read(flight.AircraftModelId) ?? throw new KeyNotFoundException($"Model with Id {flight.AircraftModelId} not found");

        return mapper.Map<AircraftModelDto>(model);
    }

    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetAll() =>
        mapper.Map<IList<FlightDto>>(await flightRepository.ReadAll());

    /// <inheritdoc/>
    public async Task<IList<PassengerDto>> GetPassengers(int flightId)
    {
        _ = await flightRepository.Read(flightId) ?? throw new KeyNotFoundException($"Flight with Id {flightId} not found");

        var tickets = await ticketRepository.ReadAll();

        var flightTickets = tickets
            .Where(t => t.FlightId == flightId)
            .ToList();

        var passengerIds = flightTickets
            .Select(t => t.PassengerId)
            .Distinct()
            .ToList();

        var passengers = new List<Passenger>();
        foreach (var id in passengerIds)
        {
            var passenger = await passengerRepository.Read(id);
            if (passenger != null)
                passengers.Add(passenger);
        }

        return mapper.Map<IList<PassengerDto>>(passengers);
    }

    /// <inheritdoc/>
    public async Task<IList<TicketDto>> GetTickets(int flightId)
    {
        _ = await flightRepository.Read(flightId) ?? throw new KeyNotFoundException($"Flight with Id {flightId} not found");

        var tickets = await ticketRepository.ReadAll();

        var result = tickets
            .Where(f => f.FlightId == flightId)
            .ToList();

        return mapper.Map<IList<TicketDto>>(result);
    }

    /// <inheritdoc/>
    public async Task<FlightDto> Update(FlightCreateUpdateDto dto, int dtoId)
    {
        var entity = await flightRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        mapper.Map(dto, entity);

        var result = await flightRepository.Update(entity);

        return mapper.Map<FlightDto>(result);
    }
}