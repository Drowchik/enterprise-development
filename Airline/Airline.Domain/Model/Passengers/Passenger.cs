using Airline.Domain.Model.Tickets;
using System.ComponentModel.DataAnnotations;

namespace Airline.Domain.Model.Passengers;

/// <summary>
/// Пассажир авиакомпании
/// </summary>
public class Passenger
{
    /// <summary>
    /// Уникальный идентификатор пассажира
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    [Key]
    [StringLength(20)]
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Имя 
    /// </summary>
    [StringLength(150)]
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия 
    /// </summary>
    [StringLength(150)]
    public required string LastName { get; set; }

    /// <summary>
    /// Отчество 
    /// </summary>
    [StringLength(150)]
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
