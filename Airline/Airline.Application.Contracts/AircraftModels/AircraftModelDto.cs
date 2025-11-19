using System.ComponentModel.DataAnnotations;

namespace Airline.Application.Contracts.AircraftModels;

/// <summary>
/// DTO модели самолёта
/// </summary>
/// <param name="Id">Уникальный идентификатор модели самолёта</param>
/// <param name="Name">Название модели самолёта</param>
/// <param name="FlightRange">Дальность полёта в км</param>
/// <param name="PassengerCapacity">Вместимость пассажиров</param>
/// <param name="CargoCapacity">Вместимость груза в тоннах</param>
public record AircraftModelDto(
    int Id,
    [Required(ErrorMessage = "Название модели обязательно")]
    [StringLength(100, ErrorMessage = "Название модели не должно превышать 100 символов")]
    string Name,
    [Required(ErrorMessage = "Дальность полёта обязательна")]
    [Range(0, 20000, ErrorMessage = "Дальность полёта должна быть в диапазоне от 0 до 20000 км")]
    double FlightRange,
    [Required(ErrorMessage = "Вместимость пассажиров обязательна")]
    [Range(1, 800, ErrorMessage = "Вместимость пассажиров должна быть от 1 до 800")]
    int PassengerCapacity,
    [Required(ErrorMessage = "Вместимость груза обязательна")]
    [Range(0, 200, ErrorMessage = "Вместимость груза должна быть от 0 до 200 тонн")]
    double CargoCapacity
);