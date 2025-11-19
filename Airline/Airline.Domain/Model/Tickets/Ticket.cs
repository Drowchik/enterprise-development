using Airline.Domain.Model.Flights;
using Airline.Domain.Model.Passengers;
using System.ComponentModel.DataAnnotations;

namespace Airline.Domain.Model.Tickets;

/// <summary>
/// Билет на авиарейс
/// </summary>
public class Ticket
{
    /// <summary>
    /// Уникальный идентификатор билета
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Ключ на рейс, к которому относится билет
    /// </summary>
    [Required]
    public required int FlightId { get; set; }

    /// <summary>
    /// Рейс, к которому относится билет
    /// </summary>
    public Flight? Flight { get; set; }

    /// <summary>
    /// Ключ на пассажира, которому принадлежит билет
    /// </summary>
    [Required]
    public required int PassengerId { get; set; }

    /// <summary>
    /// Пассажир, которому принадлежит билет
    /// </summary>
    public Passenger? Passenger { get; set; }

    /// <summary>
    /// Номер сидения
    /// </summary>
    [StringLength(10, ErrorMessage = "Номер сидения не должен превышать 10 символов")]
    [Required]
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Наличие ручной клади
    /// </summary>
    [Required]
    public required bool HasHandLuggage { get; set; }

    /// <summary>
    /// Общий вес багажа (в килограммах)
    /// </summary>
    [Range(0, 200, ErrorMessage = "Вес багажа должен быть в диапазоне от 0 до 200 кг")]
    [Required]
    public required double BaggageWeight { get; set; }
}
