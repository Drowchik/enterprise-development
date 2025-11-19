using System.ComponentModel.DataAnnotations;

namespace Airline.Application.Contracts.AircraftFamilies;

/// <summary>
/// DTO для создания/обновления семейства самолётов
/// </summary>
/// <param name="Name">Название семейства самолётов</param>
/// <param name="Manufacturer">Производитель самолётов</param>
public record AircraftFamilyCreateUpdateDto(
    [Required(ErrorMessage = "Название семейства обязательно")]
    [StringLength(100, ErrorMessage = "Название семейства не должно превышать 100 символов")]
    string Name,
    [Required(ErrorMessage = "Название производителя обязательно")]
    [StringLength(100, ErrorMessage = "Название производителя не должно превышать 100 символов")]
    string Manufacturer
);