using Airline.Domain.Model.AircraftModels;
using Airline.Domain.Model.Tickets;

namespace Airline.Domain.Model.Flights;

/// <summary>
/// Авиарейс
/// </summary>
public class Flight
{
    /// <summary>
    /// Уникальный идентификатор модели самолета.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Уникальный шифр рейса
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Пункт отправления
    /// </summary>
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// Пункт прибытия
    /// </summary>
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
