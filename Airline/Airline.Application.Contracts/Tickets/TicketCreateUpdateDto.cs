using System.ComponentModel.DataAnnotations;

namespace Airline.Application.Contracts.Tickets;

/// <summary>
/// DTO для создания/обновления билета
/// </summary>
/// <param name="FlightId">Идентификатор рейса</param>
/// <param name="PassengerId">Идентификатор пассажира</param>
/// <param name="SeatNumber">Номер сидения</param>
/// <param name="HasHandLuggage">Наличие ручной клади</param>
/// <param name="BaggageWeight">Вес багажа в кг</param>
public record TicketCreateUpdateDto(
    [Required(ErrorMessage = "Рейс обязателен")]
    int FlightId,
    [Required(ErrorMessage = "Пассажир обязателен")]
    int PassengerId,
    [Required(ErrorMessage = "Номер сидения обязателен")]
    [StringLength(10, ErrorMessage = "Номер сидения не должен превышать 10 символов")]
    string SeatNumber,
    [Required(ErrorMessage = "Необходимо указать наличие ручной клади")]
    bool HasHandLuggage,
    [Required(ErrorMessage = "Вес багажа обязателен")]
    [Range(0, 200, ErrorMessage = "Вес багажа должен быть от 0 до 200 кг")]
    double BaggageWeight
);