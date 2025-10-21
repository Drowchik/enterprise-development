using Airline.Domain.Model.AircraftModels;
using System.ComponentModel.DataAnnotations;

namespace Airline.Domain.Model.AircraftFamilies;

/// <summary>
/// Семейство самолётов
/// </summary>
public class AircraftFamily
{
    /// <summary>
    /// Уникальный идентификатор семейства самолётов
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Название семейства
    /// </summary>
    [StringLength(100, ErrorMessage = "Название семейства не должно превышать 100 символов")]
    public required string Name { get; set; }

    /// <summary>
    /// Производитель самолётов
    /// </summary>
    [StringLength(100, ErrorMessage = "Название производителя не должно превышать 100 символов")]
    public required string Manufacturer { get; set; }

    /// <summary>
    /// Список моделей
    /// </summary>
    public List<AircraftModel>? Models { get; set; } = [];
}