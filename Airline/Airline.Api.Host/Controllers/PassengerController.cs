using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;
using Airline.Application.Contracts.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления пассажирами
/// Наследуется от базового CRUD-контроллера и добавляет методы для получения связанных рейсов и билетов
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PassengerController(IPassengerService service, ILogger<PassengerController> logger) 
    : CrudControllerBase<PassengerDto, PassengerCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Получение всех рейсов, связанных с данным пассажиром
    /// </summary>
    /// <param name="id">Идентификатор пассажира</param>
    /// <returns>Список DTO рейсов</returns>
    [HttpGet("{id}/Flights")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetFlights(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetFlights), GetType().Name, id);
        try
        {
            var res = await service.GetFlights(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetFlights), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetFlights), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получение всех билетов, связанных с данным пассажиром
    /// </summary>
    /// <param name="id">Идентификатор пассажира</param>
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