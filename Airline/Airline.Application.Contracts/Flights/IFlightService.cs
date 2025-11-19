using Airline.Application.Contracts.AircraftModels;
using Airline.Application.Contracts.Passengers;
using Airline.Application.Contracts.Tickets;

namespace Airline.Application.Contracts.Flights;

/// <summary>
/// Сервис для работы с рейсами
/// </summary>
public interface IFlightService : IApplicationService<FlightDto, FlightCreateUpdateDto, int>
{
    /// <summary>
    /// Получить модель самолёта, выполняющую рейс
    /// </summary>
    /// <param name="flightId">Идентификатор рейса</param>
    /// <returns>DTO модели самолёта</returns>
    public Task<AircraftModelDto> GetAircraftModel(int flightId);

    /// <summary>
    /// Получить все билеты данного рейса
    /// </summary>
    /// <param name="flightId">Идентификатор рейса</param>
    /// <returns>Список DTO билетов</returns>
    public Task<IList<TicketDto>> GetTickets(int flightId);

    /// <summary>
    /// Получить всех пассажиров данного рейса
    /// </summary>
    /// <param name="flightId">Идентификатор рейса</param>
    /// <returns>Список DTO пассажиров</returns>
    public Task<IList<PassengerDto>> GetPassengers(int flightId);
}