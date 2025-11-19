using Airline.Domain.Model.AircraftFamilies;
using Airline.Domain.Model.AircraftModels;
using Airline.Domain.Model.Flights;
using Airline.Domain.Model.Passengers;
using Airline.Domain.Model.Tickets;

namespace Airline.Domain.Data;

/// <summary>
/// Данные для тестирования 
/// </summary>
public class DataSeeder
{
    /// <summary>
    /// Коллекция семейств самолетов
    /// </summary>
    public List<AircraftFamily> Families { get; } = [];

    /// <summary>
    /// Коллекция моделей самолета
    /// </summary>
    public List<AircraftModel> Models { get; } = [];

    /// <summary>
    /// Коллекция полетов
    /// </summary>
    public List<Flight> Flights { get; } = [];

    /// <summary>
    /// Коллекция пассажиров
    /// </summary>
    public List<Passenger> Passengers { get; } = [];

    /// <summary>
    /// Коллекция билетов
    /// </summary>
    public List<Ticket> Tickets { get; } = [];

    /// <summary>
    /// Конструктор, выполняющий инициализацию всех тестовых данных
    /// </summary>
    public DataSeeder()
    {
        Passengers.AddRange(
            [
                new Passenger { Id = 1, PassportNumber = "P210001", LastName = "Агафонов", FirstName = "Антон", Patronymic = "Алексеевич", BirthDate = new DateTime(2004, 4, 15) },
                new Passenger { Id = 2, PassportNumber = "P210002", LastName = "Журавлев", FirstName = "Сергей", Patronymic = "Александрович", BirthDate = new DateTime(2004, 9, 7) },
                new Passenger { Id = 3, PassportNumber = "P210003", LastName = "Козловская", FirstName = "Ксения", Patronymic = "Александровна", BirthDate = new DateTime(2004, 1, 22) },
                new Passenger { Id = 4, PassportNumber = "P210004", LastName = "Ксеневич", FirstName = "Максим", Patronymic = "Станиславович", BirthDate = new DateTime(2004, 11, 10) },
                new Passenger { Id = 5, PassportNumber = "P210005", LastName = "Лутфуллин", FirstName = "Глеб", Patronymic = "Айдарович", BirthDate = new DateTime(2004, 3, 28) },
                new Passenger { Id = 6, PassportNumber = "P210006", LastName = "Марченко", FirstName = "Софья", Patronymic = "Александровна", BirthDate = new DateTime(2004, 7, 12) },
                new Passenger { Id = 7, PassportNumber = "P210007", LastName = "Ретивов", FirstName = "Данила", Patronymic = "Олегович", BirthDate = new DateTime(2004, 10, 3) },
                new Passenger { Id = 8, PassportNumber = "P210008", LastName = "Сайдашев", FirstName = "Андрей", Patronymic = "Алексеевич", BirthDate = new DateTime(2003, 6, 19) },
                new Passenger { Id = 9, PassportNumber = "P210009", LastName = "Спиридонова", FirstName = "Ксения", Patronymic = "Сергеевна", BirthDate = new DateTime(2004, 9, 5) },
                new Passenger { Id = 10, PassportNumber = "P210010", LastName = "Яковлев", FirstName = "Радик", Patronymic = "Сергеевич", BirthDate = new DateTime(2005, 12, 30) }
            ]
        );

        Families.AddRange(
            [
                new AircraftFamily { Id = 1, Name = "MC-21 Series", Manufacturer = "Irkut Corporation" },
                new AircraftFamily { Id = 2, Name = "Tu-214 Line", Manufacturer = "Tupolev" },
                new AircraftFamily { Id = 3, Name = "Q400 Series", Manufacturer = "De Havilland Canada" },
                new AircraftFamily { Id = 4, Name = "Il-96 Family", Manufacturer = "Ilyushin" },
                new AircraftFamily { Id = 5, Name = "ARJ21 Family", Manufacturer = "COMAC" },
                new AircraftFamily { Id = 6, Name = "CSeries Family", Manufacturer = "Bombardier" },
                new AircraftFamily { Id = 7, Name = "Dash 8 Family", Manufacturer = "De Havilland Canada" },
                new AircraftFamily { Id = 8, Name = "Mitsubishi SpaceJet", Manufacturer = "Mitsubishi Aircraft" },
                new AircraftFamily { Id = 9, Name = "Falcon Family", Manufacturer = "Dassault Aviation" },
                new AircraftFamily { Id = 10, Name = "Yak-42 Line", Manufacturer = "Yakovlev" }
            ]
        );

        Models.AddRange(
            [
                new AircraftModel { Id = 1, Name = "MC-21-300-UT", FamilyId = 1, Family = Families[0], FlightRange = 6000, PassengerCapacity = 211, CargoCapacity = 23 },
                new AircraftModel { Id = 2, Name = "Tu-214SM-UT", FamilyId = 2, Family = Families[1], FlightRange = 6500, PassengerCapacity = 215, CargoCapacity = 25 },
                new AircraftModel { Id = 3, Name = "Q400NG-UT", FamilyId = 3, Family = Families[2], FlightRange = 2500, PassengerCapacity = 82, CargoCapacity = 8 },
                new AircraftModel { Id = 4, Name = "Il-96-400M-UT", FamilyId = 4, Family = Families[3], FlightRange = 11000, PassengerCapacity = 350, CargoCapacity = 55 },
                new AircraftModel { Id = 5, Name = "ARJ21-700-UT", FamilyId = 5, Family = Families[4], FlightRange = 3700, PassengerCapacity = 90, CargoCapacity = 10 },
                new AircraftModel { Id = 6, Name = "CS300-UT", FamilyId = 6, Family = Families[5], FlightRange = 6100, PassengerCapacity = 145, CargoCapacity = 18 },
                new AircraftModel { Id = 7, Name = "Dash8-400-UT", FamilyId = 7, Family = Families[6], FlightRange = 2400, PassengerCapacity = 78, CargoCapacity = 7 },
                new AircraftModel { Id = 8, Name = "M90-SpaceJet-UT", FamilyId = 8, Family = Families[7], FlightRange = 3300, PassengerCapacity = 88, CargoCapacity = 9 },
                new AircraftModel { Id = 9, Name = "Falcon-8X-UT", FamilyId = 9, Family = Families[8], FlightRange = 11945, PassengerCapacity = 14, CargoCapacity = 3 },
                new AircraftModel { Id = 10, Name = "Yak-42D-UT", FamilyId = 10, Family = Families[9], FlightRange = 3000, PassengerCapacity = 120, CargoCapacity = 12 }
            ]
        );

        Flights.AddRange(
            [
                new Flight
                {
                    Id = 1,
                    Code = "UT4101",
                    DeparturePoint = "KBP",
                    ArrivalPoint = "IST",
                    DepartureDate = new DateTime(2025,8,1,9,0,0),
                    ArrivalDate = new DateTime(2025,8,1,11,0,0),
                    Duration = TimeSpan.FromHours(2),
                    AircraftModelId = 1,
                    AircraftModel = Models[0]
                },
                new Flight
                {
                    Id = 2,
                    Code = "UT4102",
                    DeparturePoint = "KBP",
                    ArrivalPoint = "AMS",
                    DepartureDate = new DateTime(2025,8,2,13,0,0),
                    ArrivalDate = new DateTime(2025,8,2,16,0,0),
                    Duration = TimeSpan.FromHours(3),
                    AircraftModelId = 2,
                    AircraftModel = Models[1]
                },
                new Flight
                {
                    Id = 3,
                    Code = "UT4103",
                    DeparturePoint = "IST",
                    ArrivalPoint = "KBP",
                    DepartureDate = new DateTime(2025,8,3,10,0,0),
                    ArrivalDate = new DateTime(2025,8,3,12,0,0),
                    Duration = TimeSpan.FromHours(2),
                    AircraftModelId = 3,
                    AircraftModel = Models[2]
                },
                new Flight
                {
                    Id = 4,
                    Code = "UT4104",
                    DeparturePoint = "AMS",
                    ArrivalPoint = "CDG",
                    DepartureDate = new DateTime(2025,8,4,8,0,0),
                    ArrivalDate = new DateTime(2025,8,4,9,0,0),
                    Duration = TimeSpan.FromHours(1),
                    AircraftModelId = 4,
                    AircraftModel = Models[3]
                },
                new Flight
                {
                    Id = 5,
                    Code = "UT4105",
                    DeparturePoint = "CDG",
                    ArrivalPoint = "AMS",
                    DepartureDate = new DateTime(2025,8,5,12,0,0),
                    ArrivalDate = new DateTime(2025,8,5,13,0,0),
                    Duration = TimeSpan.FromHours(1),
                    AircraftModelId = 5,
                    AircraftModel = Models[4]
                },
                new Flight
                {
                    Id = 6,
                    Code = "UT4106",
                    DeparturePoint = "KBP",
                    ArrivalPoint = "IST",
                    DepartureDate = new DateTime(2025,8,6,19,0,0),
                    ArrivalDate = new DateTime(2025,8,6,21,0,0),
                    Duration = TimeSpan.FromHours(2),
                    AircraftModelId = 6, 
                    AircraftModel = Models[5]
                },
                new Flight
                {
                    Id = 7,
                    Code = "UT4107",
                    DeparturePoint = "AMS",
                    ArrivalPoint = "DOH",
                    DepartureDate = new DateTime(2025,8,7,6,0,0),
                    ArrivalDate = new DateTime(2025,8,7,13,0,0),
                    Duration = TimeSpan.FromHours(7),
                    AircraftModelId = 7,
                    AircraftModel = Models[6]
                },
                new Flight
                {
                    Id = 8,
                    Code = "UT4108",
                    DeparturePoint = "DOH",
                    ArrivalPoint = "AMS",
                    DepartureDate = new DateTime(2025,8,8,22,0,0),
                    ArrivalDate = new DateTime(2025,8,9,5,0,0),
                    Duration = TimeSpan.FromHours(7),
                    AircraftModelId = 8,
                    AircraftModel = Models[7]
                },
                new Flight
                {
                    Id = 9,
                    Code = "UT4109",
                    DeparturePoint = "KBP",
                    ArrivalPoint = "IST",
                    DepartureDate = new DateTime(2025,8,9,7,0,0),
                    ArrivalDate = new DateTime(2025,8,9,9,0,0),
                    Duration = TimeSpan.FromHours(2),
                    AircraftModelId = 9,
                    AircraftModel = Models[8]
                },
                new Flight
                {
                    Id = 10,
                    Code = "UT4110",
                    DeparturePoint = "WAW",
                    ArrivalPoint = "LHR",
                    DepartureDate = new DateTime(2025,8,10,14,0,0),
                    ArrivalDate = new DateTime(2025,8,10,15,30,0),
                    Duration = TimeSpan.FromHours(1),
                    AircraftModelId = 10,
                    AircraftModel = Models[9]
                }
            ]
        );

        var count = Math.Min(Passengers.Count, Flights.Count);
        for (var i = 0; i < count; ++i)
        {
            var ticket = new Ticket
            {
                Id = i + 1,
                FlightId = i + 1,
                Flight = Flights[i],
                PassengerId = i + 1,
                Passenger = Passengers[i],
                SeatNumber = $"{1 + i}A",
                HasHandLuggage = i % 2 != 0,
                BaggageWeight = i * 2
            };
            Tickets.Add(ticket);
            (Flights[i].Tickets ??= []).Add(ticket);
            (Passengers[i].Tickets ??= []).Add(ticket);
        }
    }
}
