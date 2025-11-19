using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;

namespace Airline.Application.Contracts;

/// <summary>
/// Сервис аналитики авиакомпании
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    /// Получить топ 5 рейсов по количеству пассажиров
    /// </summary>
    /// <returns>Список DTO рейсов</returns>
    public Task<IList<FlightDto>> GetTop5FlightsByPassengerCount();

    /// <summary>
    /// Получить рейсы с минимальной продолжительностью
    /// </summary>
    /// <returns>Список DTO рейсов</returns>
    public Task<IList<FlightDto>> GetFlightsWithMinimalDuration();

    /// <summary>
    /// Получить рейсы определённой модели самолёта в заданный период
    /// </summary>
    /// <param name="aircraftModelId">Идентификатор модели самолёта</param>
    /// <param name="startTime">Дата начала периода</param>
    /// <param name="endTime">Дата конца периода</param>
    /// <returns>Список DTO рейсов</returns>
    public Task<IList<FlightDto>> GetFlightsOfModelWithinPeriod(int aircraftModelId, DateTime startTime, DateTime endTime);

    /// <summary>
    /// Получить пассажиров выбранного рейса без багажа
    /// </summary>
    /// <param name="flightId">Идентификатор рейса</param>
    /// <returns>Список DTO пассажиров</returns>
    public Task<IList<PassengerDto>> GetPassengersWithZeroBaggageByFlight(int flightId);

    /// <summary>
    /// Получить рейсы между двумя аэропортами
    /// </summary>
    /// <param name="departurePoint">Аэропорт отправления</param>
    /// <param name="arrivalPoint">Аэропорт прибытия</param>
    /// <returns>Список DTO рейсов</returns>
    public Task<IList<FlightDto>> GetFlightsBetweenAirports(string departurePoint, string arrivalPoint);
}