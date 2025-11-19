using Airline.Application.Contracts.AircraftFamilies;
using Airline.Application.Contracts.Flights;

namespace Airline.Application.Contracts.AircraftModels;

/// <summary>
/// Сервис для работы с моделями самолётов
/// </summary>
public interface IAircraftModelService : IApplicationService<AircraftModelDto, AircraftModelCreateUpdateDto, int>
{
    /// <summary>
    /// Получить семейство, к которому относится модель
    /// </summary>
    /// <param name="modelId">Идентификатор модели</param>
    /// <returns>DTO семейства</returns>
    public Task<AircraftFamilyDto> GetAircraftFamily(int modelId);

    /// <summary>
    /// Получить все рейсы, выполняемые данной моделью
    /// </summary>
    /// <param name="modelId">Идентификатор модели</param>
    /// <returns>Список DTO рейсов</returns>
    public Task<IList<FlightDto>> GetFlights(int modelId);
}