using Airline.Application.Contracts;
using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Api.Host.Controllers;

/// <summary>
/// Контроллер для аналитики авиакомпании
/// Предоставляет агрегированные данные по рейсам и пассажирам
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService service, ILogger<AnalyticsController> logger) : Controller
{
    /// <summary>
    /// Получение топ 5 рейсов по количеству пассажиров
    /// </summary>
    /// <returns>Список DTO рейсов</returns>
    [HttpGet("top-flights-by-passenger-count")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetTop5FlightsByPassengerCount()
    {
        try
        {
            var result = await service.GetTop5FlightsByPassengerCount();
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in GetTop5FlightsByPassengerCount");
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Получение рейсов с минимальной продолжительностью
    /// </summary>
    /// <returns>Список DTO рейсов</returns>
    [HttpGet("flights-with-minimal-duration")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetFlightsWithMinimalDuration()
    {
        try
        {
            var result = await service.GetFlightsWithMinimalDuration();
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in GetFlightsWithMinimalDuration");
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Получение рейсов определённой модели самолёта в заданный период
    /// </summary>
    /// <param name="aircraftModelId">Идентификатор модели</param>
    /// <param name="startTime">Начало периода</param>
    /// <param name="endTime">Конец периода</param>
    /// <returns>Список DTO рейсов</returns>
    [HttpGet("flights-of-model-within-period")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetFlightsOfModelWithinPeriod(int aircraftModelId, DateTime startTime, DateTime endTime)
    {
        try
        {
            var result = await service.GetFlightsOfModelWithinPeriod(aircraftModelId, startTime, endTime);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in GetFlightsOfModelWithinPeriod");
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Получение пассажиров выбранного рейса без багажа
    /// </summary>
    /// <param name="flightId">Идентификатор рейса</param>
    /// <returns>Список DTO пассажиров</returns>
    [HttpGet("PassengersWithZeroBaggageByFlight/{flightId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<PassengerDto>>> GetPassengersWithZeroBaggageByFlight(int flightId)
    {
        try
        {
            var result = await service.GetPassengersWithZeroBaggageByFlight(flightId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in GetPassengersWithZeroBaggageByFlight");
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Получение рейсов между двумя аэропортами
    /// </summary>
    /// <param name="departurePoint">Аэропорт отправления</param>
    /// <param name="arrivalPoint">Аэропорт прибытия</param>
    /// <returns>Список DTO рейсов</returns>
    [HttpGet("FlightsBetweenAirports")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetFlightsBetweenAirports(string departurePoint, string arrivalPoint)
    {
        try
        {
            var result = await service.GetFlightsBetweenAirports(departurePoint, arrivalPoint);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in GetFlightsBetweenAirports");
            return StatusCode(500, ex.Message);
        }
    }
}