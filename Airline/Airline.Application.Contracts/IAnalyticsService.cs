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
    /// Получить рейсы определённой модели в заданный период
    /// </summary>
    /// <returns>Список DTO рейсов</returns>
    public Task<IList<FlightDto>> GetFlightsOfModelWithinPeriod();

    /// <summary>
    /// Получить пассажиров без багажа
    /// </summary>
    /// <returns>Список DTO пассажиров</returns>
    public Task<IList<PassengerDto>> GetPassengersWithZeroBaggage();

    /// <summary>
    /// Получить рейсы между двумя аэропортами
    /// </summary>
    /// <returns>Список DTO рейсов</returns>
    public Task<IList<FlightDto>> GetFlightsBetweenAirports();
}