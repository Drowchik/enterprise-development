using Airline.Domain.Model.Tickets;

namespace Airline.Domain.Model.Passengers;

/// <summary>
/// Пассажир авиакомпании
/// </summary>
public class Passenger
{
    /// <summary>
    /// Уникальный идентификатор пассажира
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Имя 
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия 
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Отчество 
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Дата рождения 
    /// </summary>
    public required DateTime BirthDate { get; set; }

    /// <summary>
    /// Список билетов, принадлежащих пассажиру
    /// </summary>
    public List<Ticket>? Tickets { get; set; } = [];
}
