using System.ComponentModel.DataAnnotations;

namespace Airline.Application.Contracts.Flights;

/// <summary>
/// DTO для создания/обновления авиарейса
/// </summary>
/// <param name="Code">Шифр рейса</param>
/// <param name="DeparturePoint">Пункт отправления</param>
/// <param name="ArrivalPoint">Пункт прибытия</param>
/// <param name="DepartureDate">Дата и время отправления</param>
/// <param name="ArrivalDate">Дата и время прибытия</param>
/// <param name="Duration">Время в пути</param>
/// <param name="AicraftModelId">Идентификатор модели самолёта</param>
public record FlightCreateUpdateDto(
    [Required(ErrorMessage = "Шифр рейса обязателен")]
    [StringLength(10, ErrorMessage = "Шифр не должен превышать 10 символов")]
    string Code,
    [Required(ErrorMessage = "Пункт отправления обязателен")]
    [StringLength(100, ErrorMessage = "Пункт отправления не должен превышать 100 символов")]
    string DeparturePoint,
    [Required(ErrorMessage = "Пункт прибытия обязателен")]
    [StringLength(100, ErrorMessage = "Пункт прибытия не должен превышать 100 символов")]
    string ArrivalPoint,
    DateTime? DepartureDate,
    DateTime? ArrivalDate,
    TimeSpan? Duration,
    [Required(ErrorMessage = "Модель самолёта обязательна")]
    int AicraftModelId
);