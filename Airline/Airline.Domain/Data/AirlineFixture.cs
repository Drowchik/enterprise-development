using Airline.Domain.Model.AircraftFamilies;
using Airline.Domain.Model.AircraftModels;
using Airline.Domain.Model.Flights;
using Airline.Domain.Model.Passengers;
using Airline.Domain.Model.Tickets;

namespace Airline.Domain.Data;

/// <summary>
/// Данные для тестирования 
/// </summary>
public class AirlineTestsFixture
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

    private int _ticketId = 1;

    public AirlineTestsFixture()
    {
        Families.AddRange(
            [
                new AircraftFamily { Id = 101, Name = "MC-21 Series", Manufacturer = "Irkut Corporation" },
                new AircraftFamily { Id = 102, Name = "Tu-214 Line", Manufacturer = "Tupolev" },
                new AircraftFamily { Id = 103, Name = "Q400 Series", Manufacturer = "De Havilland Canada" },
                new AircraftFamily { Id = 104, Name = "Il-96 Family", Manufacturer = "Ilyushin" },
                new AircraftFamily { Id = 105, Name = "ARJ21 Family", Manufacturer = "COMAC" },
                new AircraftFamily { Id = 106, Name = "CSeries Family", Manufacturer = "Bombardier" },
                new AircraftFamily { Id = 107, Name = "Dash 8 Family", Manufacturer = "De Havilland Canada" },
                new AircraftFamily { Id = 108, Name = "Mitsubishi SpaceJet", Manufacturer = "Mitsubishi Aircraft" },
                new AircraftFamily { Id = 109, Name = "Falcon Family", Manufacturer = "Dassault Aviation" },
                new AircraftFamily { Id = 110, Name = "Yak-42 Line", Manufacturer = "Yakovlev" }
            ]
        );

        Models.AddRange(
            [
                new AircraftModel { Id = 201, Name = "MC-21-300-UT", Family = Families[0], FlightRange = 6000, PassengerCapacity = 211, CargoCapacity = 23 },
                new AircraftModel { Id = 202, Name = "Tu-214SM-UT", Family = Families[1], FlightRange = 6500, PassengerCapacity = 215, CargoCapacity = 25 },
                new AircraftModel { Id = 203, Name = "Q400NG-UT", Family = Families[2], FlightRange = 2500, PassengerCapacity = 82, CargoCapacity = 8 },
                new AircraftModel { Id = 204, Name = "Il-96-400M-UT", Family = Families[3], FlightRange = 11000, PassengerCapacity = 350, CargoCapacity = 55 },
                new AircraftModel { Id = 205, Name = "ARJ21-700-UT", Family = Families[4], FlightRange = 3700, PassengerCapacity = 90, CargoCapacity = 10 },
                new AircraftModel { Id = 206, Name = "CS300-UT", Family = Families[5], FlightRange = 6100, PassengerCapacity = 145, CargoCapacity = 18 },
                new AircraftModel { Id = 207, Name = "Dash8-400-UT", Family = Families[6], FlightRange = 2400, PassengerCapacity = 78, CargoCapacity = 7 },
                new AircraftModel { Id = 208, Name = "M90-SpaceJet-UT", Family = Families[7], FlightRange = 3300, PassengerCapacity = 88, CargoCapacity = 9 },
                new AircraftModel { Id = 209, Name = "Falcon-8X-UT", Family = Families[8], FlightRange = 11945, PassengerCapacity = 14, CargoCapacity = 3 },
                new AircraftModel { Id = 210, Name = "Yak-42D-UT", Family = Families[9], FlightRange = 3000, PassengerCapacity = 120, CargoCapacity = 12 },
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
                    AircraftModel =Models[5]
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
                    AircraftModel = Models[9]
                }
            ]
        );

        Passengers.AddRange(
            [
                new Passenger
                {
                    PassportNumber = "P210001",
                    LastName = "Агафонов",
                    FirstName = "Антон",
                    Patronymic = "Алексеевич",
                    BirthDate = new DateTime(2004, 4, 15)
                },
                new Passenger
                {
                    PassportNumber = "P210002",
                    LastName = "Журавлев",
                    FirstName = "Сергей",
                    Patronymic = "Александрович",
                    BirthDate = new DateTime(2004, 9, 7)
                },
                new Passenger
                {
                    PassportNumber = "P210003",
                    LastName = "Козловская",
                    FirstName = "Ксения",
                    Patronymic = "Александровна",
                    BirthDate = new DateTime(2004, 1, 22)
                },
                new Passenger
                {
                    PassportNumber = "P210004",
                    LastName = "Ксеневич",
                    FirstName = "Максим",
                    Patronymic = "Станиславович",
                    BirthDate = new DateTime(2004, 11, 10)
                },
                new Passenger
                {
                    PassportNumber = "P210005",
                    LastName = "Лутфуллин",
                    FirstName = "Глеб",
                    Patronymic = "Айдарович",
                    BirthDate = new DateTime(2004, 3, 28)
                },
                new Passenger
                {
                    PassportNumber = "P210006",
                    LastName = "Марченко",
                    FirstName = "Софья",
                    Patronymic = "Александровна",
                    BirthDate = new DateTime(2004, 7, 12)
                },
                new Passenger
                {
                    PassportNumber = "P210007",
                    LastName = "Ретивов",
                    FirstName = "Данила",
                    Patronymic = "Олегович",
                    BirthDate = new DateTime(2004, 10, 3)
                },
                new Passenger
                {
                    PassportNumber = "P210008",
                    LastName = "Сайдашев",
                    FirstName = "Андрей",
                    Patronymic = "Алексеевич",
                    BirthDate = new DateTime(2003, 6, 19)
                },
                new Passenger
                {
                    PassportNumber = "P210009",
                    LastName = "Спиридонова",
                    FirstName = "Ксения",
                    Patronymic = "Сергеевна",
                    BirthDate = new DateTime(2004, 9, 5)
                },
                new Passenger
                {
                    PassportNumber = "P210010",
                    LastName = "Яковлев",
                    FirstName = "Радик",
                    Patronymic = "Сергеевич",
                    BirthDate = new DateTime(2005, 12, 30)
                }
            ]
        );
        var count = Math.Min(Passengers.Count, Flights.Count);
        for (var i = 0; i < count; ++i)
        {
            AddTicket(Flights[i], Passengers[i], $"{1 + i}A", i % 2 != 0, i * 2);
        }

    }
    private void AddTicket(Flight flight, Passenger passenger, string seat, bool hasHand, double baggage)
    {
        var t = new Ticket
        {
            Id = _ticketId++,
            Flight = flight,
            Passenger = passenger,
            SeatNumber = seat,
            HasHandLuggage = hasHand,
            BaggageWeight = baggage
        };

        Tickets.Add(t);
        (flight.Tickets ??= []).Add(t);
        (passenger.Tickets ??= []).Add(t);
    }
}
