using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;

namespace Airline.Application.Contracts.Tickets;

/// <summary>
/// Сервис для работы с билетами
/// </summary>
public interface ITicketService : IApplicationService<TicketDto, TicketCreateUpdateDto, int>
{
    /// <summary>
    /// Получить рейс, к которому относится билет
    /// </summary>
    /// <param name="ticketId">Идентификатор билета</param>
    /// <returns>DTO рейса</returns>
    public Task<FlightDto> GetFlight(int ticketId);

    /// <summary>
    /// Получить пассажира, которому принадлежит билет
    /// </summary>
    /// <param name="ticketId">Идентификатор билета</param>
    /// <returns>DTO пассажира</returns>
    public Task<PassengerDto> GetPassenger(int ticketId);
}