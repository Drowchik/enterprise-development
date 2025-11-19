using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Tickets;

namespace Airline.Application.Contracts.Passengers;

/// <summary>
/// Сервис для работы с пассажирами
/// </summary>
public interface IPassengerService : IApplicationService<PassengerDto, PassengerCreateUpdateDto, int>
{
    /// <summary>
    /// Получить все билеты пассажира
    /// </summary>
    /// <param name="passengerId">Идентификатор пассажира</param>
    /// <returns>Список DTO билетов</returns>
    public Task<IList<TicketDto>> GetTickets(int passengerId);

    /// <summary>
    /// Получить все рейсы пассажира
    /// </summary>
    /// <param name="passengerId">Идентификатор пассажира</param>
    /// <returns>Список DTO рейсов</returns>
    public Task<IList<FlightDto>> GetFlights(int passengerId);
}