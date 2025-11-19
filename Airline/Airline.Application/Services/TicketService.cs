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
/// Сервис для управления семействами самолётов и получения связанных моделей
/// </summary>
/// <param name="ticketRepository">Репозиторий для операций с сущностями билетов</param>
/// <param name="flightRepository">Репозиторий для операций с сущностями рейсов</param>
/// <param name="passengerRepository">Репозиторий для операций с сущностями пассажиров</param>
/// <param name="mapper">Маппер для преобразования доменных моделей в DTO и обратно</param>
public class TicketService(
    IRepository<Ticket, int> ticketRepository, 
    IRepository<Flight, int> flightRepository, 
    IRepository<Passenger, int> passengerRepository,
    IMapper mapper
) : ITicketService
{
    /// <inheritdoc/>
    public async Task<TicketDto> Create(TicketCreateUpdateDto dto)
    {
        var entity = mapper.Map<Ticket>(dto);

        var last = await ticketRepository.ReadAll();
        entity.Id = last.Any() ? last.Max(x => x.Id) + 1 : 1;

        var result = await ticketRepository.Create(entity);

        return mapper.Map<TicketDto>(result);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int dtoId) =>
        await ticketRepository.Delete(dtoId);

    /// <inheritdoc/>
    public async Task<TicketDto?> Get(int dtoId)
    {
        var entity = await ticketRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        return mapper.Map<TicketDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IList<TicketDto>> GetAll() =>
        mapper.Map<IList<TicketDto>>(await ticketRepository.ReadAll());

    /// <inheritdoc/>
    public async Task<FlightDto> GetFlight(int ticketId)
    {
        var ticket = await ticketRepository.Read(ticketId) ?? throw new KeyNotFoundException($"Ticket with Id {ticketId} not found");

        var flight = await flightRepository.Read(ticket.FlightId) ?? throw new KeyNotFoundException($"Flight with Id {ticket.FlightId} not found");

        return mapper.Map<FlightDto>(flight);
    }

    /// <inheritdoc/>
    public async Task<PassengerDto> GetPassenger(int ticketId)
    {
        var ticket = await ticketRepository.Read(ticketId) ?? throw new KeyNotFoundException($"Ticket with Id {ticketId} not found");

        var passenger = await passengerRepository.Read(ticket.PassengerId) ?? throw new KeyNotFoundException($"Passenger with Id {ticket.PassengerId} not found");

        return mapper.Map<PassengerDto>(passenger);
    }

    /// <inheritdoc/>
    public async Task<TicketDto> Update(TicketCreateUpdateDto dto, int dtoId)
    {
        var entity = await ticketRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        mapper.Map(dto, entity);

        var result = await ticketRepository.Update(entity);

        return mapper.Map<TicketDto>(result);
    }
}