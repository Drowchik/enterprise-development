using Airline.Domain.Model.Flights;
using Airline.Domain.Model.Passengers;

namespace Airline.Domain.Model.Tickets;

/// <summary>
/// Билет на авиарейс
/// </summary>
public class Ticket
{
    /// <summary>
    /// Уникальный идентификатор билета
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Ключ на рейс, к которому относится билет
    /// </summary>
    public required int FlightId { get; set; }

    /// <summary>
    /// Рейс, к которому относится билет
    /// </summary>
    public Flight? Flight { get; set; }

    /// <summary>
    /// Ключ на пассажира, которому принадлежит билет
    /// </summary>
    public required int PassengerId { get; set; }

    /// <summary>
    /// Пассажир, которому принадлежит билет
    /// </summary>
    public Passenger? Passenger { get; set; }

    /// <summary>
    /// Номер сидения
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Наличие ручной клади
    /// </summary>
    public required bool HasHandLuggage { get; set; }

    /// <summary>
    /// Общий вес багажа (в килограммах)
    /// </summary>
    public required double BaggageWeight { get; set; }
}
