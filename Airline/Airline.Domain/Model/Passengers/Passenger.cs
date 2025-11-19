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
    [StringLength(20, ErrorMessage = "Номер паспорт не должен превышать 20 символов")]
    [Required]
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Имя 
    /// </summary>
    [StringLength(150, ErrorMessage = "Имя не должно превышать 150 символов")]
    [Required]
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия 
    /// </summary>
    [StringLength(150, ErrorMessage = "Фамилия не должна превышать 150 символов")]
    [Required]
    public required string LastName { get; set; }

    /// <summary>
    /// Отчество 
    /// </summary>
    [StringLength(150, ErrorMessage = "Отчество не должно превышать 150 символов")]
    public string? Patronymic { get; set; }

    /// <summary>
    /// Дата рождения 
    /// </summary>
    [Required]
    public required DateTime BirthDate { get; set; }

    /// <summary>
    /// Список билетов, принадлежащих пассажиру
    /// </summary>
    public List<Ticket>? Tickets { get; set; } = [];
}
