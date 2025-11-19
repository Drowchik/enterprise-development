using Airline.Application.Contracts.AircraftModels;
using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;
using Airline.Application.Contracts.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления рейсами
/// Наследуется от базового CRUD-контроллера и добавляет методы для получения связанных пассажиров и модели самолёта
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FlightController(IFlightService service, ILogger<FlightController> logger) 
    : CrudControllerBase<FlightDto, FlightCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Получение модели самолётов, связанной с данным рейсом
    /// </summary>
    /// <param name="id">Идентификатор рейса</param>
    /// <returns>DTO модели</returns>
    [HttpGet("{id}/AircraftModel")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<AircraftModelDto>> GetAircraftModel(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetAircraftModel), GetType().Name, id);
        try
        {
            var res = await service.GetAircraftModel(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetAircraftModel), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetAircraftModel), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получение всех пассажиров, летящих данным рейсом
    /// </summary>
    /// <param name="id">Идентификатор рейса</param>
    /// <returns>Список DTO пассажиров</returns>
    [HttpGet("{id}/Passengers")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<PassengerDto>>> GetPassengers(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetPassengers), GetType().Name, id);
        try
        {
            var res = await service.GetPassengers(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetPassengers), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetPassengers), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получение всех билетов, связанных с данным рейсом
    /// </summary>
    /// <param name="id">Идентификатор рейса</param>
    /// <returns>Список DTO билетов</returns>
    [HttpGet("{id}/Tickets")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<TicketDto>>> GetTickets(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetTickets), GetType().Name, id);
        try
        {
            var res = await service.GetTickets(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetTickets), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetTickets), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}