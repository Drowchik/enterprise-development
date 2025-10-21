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
    [StringLength(10)]
    public required string Code { get; set; }

    /// <summary>
    /// Пункт отправления
    /// </summary>
    [StringLength(100)]
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// Пункт прибытия
    /// </summary>
    [StringLength(100)]
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
    /// Модель самолёта, выполняющая рейс
    /// </summary>
    public required AircraftModel AircraftModel { get; set; }

    /// <summary>
    /// Список билетов, связанных с рейсом
    /// </summary>
    public List<Ticket>? Tickets { get; set; } = [];
}
