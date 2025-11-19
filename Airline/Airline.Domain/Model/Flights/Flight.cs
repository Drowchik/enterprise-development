using Airline.Domain.Model.AircraftModels;
using Airline.Domain.Model.Tickets;
using System.ComponentModel.DataAnnotations;

namespace Airline.Domain.Model.Flights;

/// <summary>
/// Авиарейс
/// </summary>
public class Flight
{
    /// <summary>
    /// Уникальный идентификатор модели самолета.
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Уникальный шифр рейса
    /// </summary>
    [StringLength(10, ErrorMessage = "Шифр не должен превышать 10 символов")]
    [Required]
    public required string Code { get; set; }

    /// <summary>
    /// Пункт отправления
    /// </summary>
    [StringLength(100, ErrorMessage = "Название пункта отправления не должно превышать 100 символов")]
    [Required]
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// Пункт прибытия
    /// </summary>
    [StringLength(100, ErrorMessage = "Название пункта прибытия не должно превышать 100 символов")]
    [Required]
    public required string ArrivalPoint { get; set; }

    /// <summary>
    /// Дата и время отправления
    /// </summary>
    public DateTime? DepartureDate { get; set; }

    /// <summary>
    /// Дата и время прибытия
    /// </summary>
    public DateTime? ArrivalDate { get; set; }

    /// <summary>
    /// Время в пути
    /// </summary>
    public TimeSpan? Duration { get; set; }

    /// <summary>
    /// Ключ на модель самолёта, выполняющую рейс
    /// </summary>
    [Required]
    public required int AicraftModelId { get; set; }

    /// <summary>
    /// Модель самолёта, выполняющая рейс
    /// </summary>
    public AircraftModel? AircraftModel { get; set; }

    /// <summary>
    /// Список билетов, связанных с рейсом
    /// </summary>
    public List<Ticket>? Tickets { get; set; } = [];
}
