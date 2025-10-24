using Airline.Domain.Data;

namespace Airline.Tests;


/// <summary>
/// Тесты для доменной области авиакомпании
/// </summary>
public class AirlineTests(DataSeeder data) : IClassFixture<DataSeeder>
{
    /// <summary>
    /// Проверяет, что корректно возвращаются топ 5 авиарейсов по количеству перевезенных пассажиров
    /// </summary>
    [Fact]
    public void Top5FlightsByPassengerCount()
    {
        var expectedIds = new List<int> { 1, 2, 3, 4, 5 };
        var flightsIds = data.Flights
            .OrderByDescending(f => f.Tickets!.Count)
            .Take(5)
            .Select(f => f.Id)
            .ToList();

        Assert.Equal(expectedIds, flightsIds);
    }

    /// <summary>
    /// Проверяет, что корректно определяется список рейсов с минимальным временем в пути
    /// </summary>
    [Fact]
    public void FlightsWithMinimalDuration()
    {
        var expectedIds = new List<int> { 4, 5, 10 };

        var minDuration = data.Flights
            .Min(f => f.Duration!.Value);

        var flightIds = data.Flights
            .Where(f => f.Duration == minDuration)
            .Select(f => f.Id)
            .ToList();

        Assert.Equal(expectedIds, flightIds);
    }

    /// <summary>
    /// Проверяет, что корректно возвращаются рейсы выбранной модели самолёта в указанном периоде
    /// </summary>
    [Fact]
    public void FlightsOfModelWithinPeriod()
    {
        var modelId = 201;
        var from = new DateTime(2025, 8, 1);
        var to = new DateTime(2025, 8, 31);

        var flights = data.Flights
            .Where(f => f.AircraftModel.Id == modelId
                        && f.DepartureDate >= from
                        && f.DepartureDate <= to)
            .ToList();

        Assert.All(flights, f =>
            Assert.True(f.AircraftModel.Id == modelId
                        && f.DepartureDate >= from
                        && f.DepartureDate <= to));
    }

    /// <summary>
    /// Проверяет, что корректно возвращаются пассажиры выбранного рейса с нулевым весом багажа, отсортированные по ФИО
    /// </summary>
    [Fact]
    public void PassengersWithZeroBaggage()
    {
        var passengers = data.Tickets
            .Where(t => t.Flight.Code == "UT4101" && t.BaggageWeight == 0)
            .Select(t => t.Passenger)
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .ThenBy(p => p.Patronymic)
            .ToList();

        Assert.All(passengers, p => Assert.Equal(0, data.Tickets.First(t => t.Passenger == p).BaggageWeight));
    }

    /// <summary>
    /// Проверяет, что корректно возвращаются рейсы по выбранным пунктам отправления и прибытия
    /// </summary>
    [Fact]
    public void FlightsBetweenAirports()
    {
        var expectedIds = new List<int> { 1, 6, 9 };

        var flightIds = data.Flights
            .Where(f => f.DeparturePoint == "KBP" && f.ArrivalPoint == "IST")
            .Select(f => f.Id)
            .ToList();

        Assert.Equal(expectedIds, flightIds);
    }


}