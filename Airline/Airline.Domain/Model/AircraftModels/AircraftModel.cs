using Airline.Domain.Model.AircraftFamilies;
using Airline.Domain.Model.Flights;

namespace Airline.Domain.Model.AircraftModels;

/// <summary>
/// Модель самолёта
/// </summary>
public class AircraftModel
{
    /// <summary>
    /// Уникальный идентификатор модели самолёта
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название модели самолёта
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Ключ на семейство самолёта, к которому относится модель
    /// </summary>
    public required int FamilyId { get; set; }

    /// <summary>
    /// Семейство самолёта, к которому относится модель
    /// </summary>
    public AircraftFamily? Family { get; set; }

    /// <summary>
    /// Дальность полёта (в км)
    /// </summary>
    public required double FlightRange { get; set; }

    /// <summary>
    /// Вместимость пассажиров
    /// </summary>
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Вместимость груза (в тоннах)
    /// </summary>
    public required double CargoCapacity { get; set; }

    /// <summary>
    /// Список рейсов, выполняемых данной моделью самолёта
    /// </summary>
    public List<Flight>? Flights { get; set; } = [];
}
