using Airline.Application.Contracts.AircraftFamilies;
using Airline.Application.Contracts.AircraftModels;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления семействами самолётов
/// Наследуется от базового CRUD-контроллера и добавляет методы для получения связанных моделей самолётов
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AircraftFamilyController(IAircraftFamilyService service, ILogger<AircraftFamilyController> logger) 
    : CrudControllerBase<AircraftFamilyDto, AircraftFamilyCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Получение всех моделей самолётов, связанных с данным семейством
    /// </summary>
    /// <param name="id">Идентификатор семейства</param>
    /// <returns>Список DTO моделей</returns>
    [HttpGet("{id}/AircraftModels")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<AircraftModelDto>>> GetAircraftModels(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetAircraftModels), GetType().Name, id);
        try
        {
            var res = await service.GetAircraftModels(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetAircraftModels), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetAircraftModels), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}