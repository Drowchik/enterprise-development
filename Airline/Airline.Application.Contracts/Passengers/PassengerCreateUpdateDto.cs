using System.ComponentModel.DataAnnotations;

namespace Airline.Application.Contracts.Passengers;

/// <summary>
/// DTO для создания/обновления пассажира
/// </summary>
/// <param name="PassportNumber">Номер паспорта</param>
/// <param name="FirstName">Имя пассажира</param>
/// <param name="LastName">Фамилия пассажира</param>
/// <param name="Patronymic">Отчество пассажира</param>
/// <param name="BirthDate">Дата рождения пассажира</param>
public record PassengerCreateUpdateDto(
    [Required(ErrorMessage = "Номер паспорта обязателен")]
    [StringLength(20, ErrorMessage = "Номер паспорта не должен превышать 20 символов")]
    string PassportNumber,
    [Required(ErrorMessage = "Имя обязательно")]
    [StringLength(150, ErrorMessage = "Имя не должно превышать 150 символов")]
    string FirstName,
    [Required(ErrorMessage = "Фамилия обязательна")]
    [StringLength(150, ErrorMessage = "Фамилия не должна превышать 150 символов")]
    string LastName,
    [StringLength(150, ErrorMessage = "Отчество не должно превышать 150 символов")]
    string? Patronymic,
    [Required(ErrorMessage = "Дата рождения обязательна")]
    DateTime BirthDate
);