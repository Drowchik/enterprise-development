using Airline.Domain.Model.AircraftFamilies;
using Airline.Domain.Model.Flights;
using System.ComponentModel.DataAnnotations;

namespace Airline.Domain.Model.AircraftModels;

/// <summary>
/// Модель самолёта
/// </summary>
public class AircraftModel
{
    /// <summary>
    /// Уникальный идентификатор модели самолёта
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Название модели самолёта
    /// </summary>
    [StringLength(100, ErrorMessage = "Название модели не должно превышать 100 символов")]
    public required string Name { get; set; }

    /// <summary>
    /// Семейство самолёта, к которому относится модель
    /// </summary>
    public required AircraftFamily Family { get; set; }

    /// <summary>
    /// Дальность полёта (в км)
    /// </summary>
    [Range(0, 20000, ErrorMessage = "Дальность полёта должна быть в диапазоне от 0 до 20 000 км")]
    public required double FlightRange { get; set; }

    /// <summary>
    /// Вместимость пассажиров
    /// </summary>
    [Range(1, 800, ErrorMessage = "Вместимость пассажиров должна быть от 1 до 800")]
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Вместимость груза (в тоннах)
    /// </summary>
    [Range(0, 200, ErrorMessage = "Вместимость груза должна быть от 0 до 200 тонн")]
    public required double CargoCapacity { get; set; }

    /// <summary>
    /// Список рейсов, выполняемых данной моделью самолёта
    /// </summary>
    public List<Flight>? Flights { get; set; } = [];
}