using Airline.Domain.Model.AircraftModels;

namespace Airline.Domain.Model.AircraftFamilies;

/// <summary>
/// Семейство самолётов
/// </summary>
public class AircraftFamily
{
    /// <summary>
    /// Уникальный идентификатор семейства самолётов
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название семейства
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Производитель самолётов
    /// </summary>
    public required string Manufacturer { get; set; }

    /// <summary>
    /// Список моделей
    /// </summary>
    public List<AircraftModel>? Models { get; set; } = [];
}
