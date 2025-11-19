using Airline.Application.Contracts.AircraftModels;

namespace Airline.Application.Contracts.AircraftFamilies;

/// <summary>
/// Сервис для работы с семействами самолётов
/// </summary>
public interface IAircraftFamilyService : IApplicationService<AircraftFamilyDto, AircraftFamilyCreateUpdateDto, int>
{
    /// <summary>
    /// Получить все модели самолётов данного семейства
    /// </summary>
    /// <param name="familyId">Идентификатор семейства</param>
    /// <returns>Список DTO моделей</returns>
    public Task<IList<AircraftModelDto>> GetAircraftModels(int familyId);
}