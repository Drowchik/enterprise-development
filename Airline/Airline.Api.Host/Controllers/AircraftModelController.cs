using Airline.Application.Contracts.AircraftFamilies;
using Airline.Application.Contracts.AircraftModels;
using Airline.Application.Contracts.Flights;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления моделями самолётов
/// Наследуется от базового CRUD-контроллера и добавляет методы для получения связанных семейств самолётов и рейсов
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AircraftModelController(IAircraftModelService service, ILogger<AircraftModelController> logger) 
    : CrudControllerBase<AircraftModelDto, AircraftModelCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Получение семейства самолётов, связанного с данной моделью
    /// </summary>
    /// <param name="id">Идентификатор модели</param>
    /// <returns>DTO семейства</returns>
    [HttpGet("{id}/AircraftFamily")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<AircraftFamilyDto>> GetAircraftFamily(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetAircraftFamily), GetType().Name, id);
        try
        {
            var res = await service.GetAircraftFamily(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetAircraftFamily), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetAircraftFamily), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получение всех рейсов, связанных с данной моделью
    /// </summary>
    /// <param name="id">Идентификатор модели</param>
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
}