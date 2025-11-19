using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;
using Airline.Application.Contracts.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления билетами
/// Наследуется от базового CRUD-контроллера и добавляет методы для получения связанного пассажира и рейса
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TicketController(ITicketService service, ILogger<TicketController> logger) 
    : CrudControllerBase<TicketDto, TicketCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Получение пассажира, которому принадлежит данный билет
    /// </summary>
    /// <param name="id">Идентификатор билета</param>
    /// <returns>DTO пассажира</returns>
    [HttpGet("{id}/Passenger")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<PassengerDto>> GetPassenger(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetPassenger), GetType().Name, id);
        try
        {
            var res = await service.GetPassenger(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetPassenger), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetPassenger), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получение рейса, к которому прикреплен данный билет
    /// </summary>
    /// <param name="id">Идентификатор билета</param>
    /// <returns>DTO рейса</returns>
    [HttpGet("{id}/Flight")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<FlightDto>> GetFlight(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetFlight), GetType().Name, id);
        try
        {
            var res = await service.GetFlight(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetFlight), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetFlight), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}