using System.ComponentModel.DataAnnotations;

namespace Airline.Application.Contracts.AircraftFamilies;

/// <summary>
/// DTO семейства самолётов
/// </summary>
/// <param name="Id">Уникальный идентификатор семейства самолётов</param>
/// <param name="Name">Название семейства самолётов</param>
/// <param name="Manufacturer">Производитель самолётов</param>
public record AircraftFamilyDto(
    int Id,
    [Required(ErrorMessage = "Название семейства обязательно")]
    [StringLength(100, ErrorMessage = "Название семейства не должно превышать 100 символов")]
    string Name,
    [Required(ErrorMessage = "Название производителя обязательно")]
    [StringLength(100, ErrorMessage = "Название производителя не должно превышать 100 символов")]
    string Manufacturer
);