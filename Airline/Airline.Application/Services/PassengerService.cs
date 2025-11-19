using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;
using Airline.Application.Contracts.Tickets;
using Airline.Domain;
using Airline.Domain.Model.Flights;
using Airline.Domain.Model.Passengers;
using Airline.Domain.Model.Tickets;
using AutoMapper;

namespace Airline.Application.Services;

/// <summary>
/// Сервис для управления пассажирами и получения связанных моделей
/// </summary>
/// <param name="passengerRepository">Репозиторий для операций с сущностями пассажиров</param>
/// <param name="ticketRepository">Репозиторий для операций с сущностями билетов</param>
/// <param name="flightRepository">Репозиторий для операций с сущностями рейсов</param>
/// <param name="mapper">Маппер для преобразования доменных моделей в DTO и обратно</param>
public class PassengerService(
    IRepository<Passenger, int> passengerRepository, 
    IRepository<Ticket, int> ticketRepository,
    IRepository<Flight, int> flightRepository,
    IMapper mapper
) : IPassengerService
{
    /// <inheritdoc/>
    public async Task<PassengerDto> Create(PassengerCreateUpdateDto dto)
    {
        var entity = mapper.Map<Passenger>(dto);

        var last = await passengerRepository.ReadAll();
        entity.Id = last.Any() ? last.Max(x => x.Id) + 1 : 1;

        var result = await passengerRepository.Create(entity);

        return mapper.Map<PassengerDto>(result);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int dtoId) =>
        await passengerRepository.Delete(dtoId);

    /// <inheritdoc/>
    public async Task<PassengerDto?> Get(int dtoId)
    {
        var entity = await passengerRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        return mapper.Map<PassengerDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IList<PassengerDto>> GetAll() =>
        mapper.Map<IList<PassengerDto>>(await passengerRepository.ReadAll());

    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetFlights(int passengerId)
    {
        _ = await passengerRepository.Read(passengerId) ?? throw new KeyNotFoundException($"Passenger with Id {passengerId} not found");

        var tickets = await ticketRepository.ReadAll();

        var passengerTickets = tickets
            .Where(t => t.PassengerId == passengerId)
            .ToList();

        var flightIds = passengerTickets
            .Select(t => t.FlightId)
            .Distinct()
            .ToList();

        var flights = new List<Flight>();
        foreach (var id in flightIds)
        {
            var flight = await flightRepository.Read(id);
            if (flight != null)
                flights.Add(flight);
        }

        return mapper.Map<IList<FlightDto>>(flights);
    }

    /// <inheritdoc/>
    public async Task<IList<TicketDto>> GetTickets(int passengerId)
    {
        _ = await passengerRepository.Read(passengerId) ?? throw new KeyNotFoundException($"Passenger with Id {passengerId} not found");

        var tickets = await ticketRepository.ReadAll();

        var result = tickets
            .Where(f => f.PassengerId == passengerId)
            .ToList();

        return mapper.Map<IList<TicketDto>>(result);
    }

    /// <inheritdoc/>
    public async Task<PassengerDto> Update(PassengerCreateUpdateDto dto, int dtoId)
    {
        var entity = await passengerRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        mapper.Map(dto, entity);

        var result = await passengerRepository.Update(entity);

        return mapper.Map<PassengerDto>(result);
    }
}