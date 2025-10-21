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
    /// Ссылка на рейс, к которому относится билет
    /// </summary>
    public required Flight Flight { get; set; }

    /// <summary>
    /// Ссылка на пассажира, которому принадлежит билет
    /// </summary>
    public required Passenger Passenger { get; set; }

    /// <summary>
    /// Номер сидения
    /// </summary>
    [StringLength(10)]
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Наличие ручной клади
    /// </summary>
    public required bool HasHandLuggage { get; set; }

    /// <summary>
    /// Общий вес багажа (в килограммах)
    /// </summary>
    [Range(0, 200, ErrorMessage = "Вес багажа должен быть в диапазоне от 0 до 200 кг")]
    public required double BaggageWeight { get; set; }
}
