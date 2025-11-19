using Airline.Application.Contracts;
using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;
using Airline.Domain;
using Airline.Domain.Model.Flights;
using Airline.Domain.Model.Passengers;
using Airline.Domain.Model.Tickets;
using AutoMapper;

namespace Airline.Application.Services;

/// <summary>
/// Сервис аналитики авиакомпании для получения агрегированных данных по рейсам и пассажирам
/// </summary>
/// <param name="flightRepository">Репозиторий для операций с рейсами</param>
/// <param name="passengerRepository">Репозиторий для операций с пассажирами</param>
/// <param name="ticketRepository">Репозиторий для операций с билетами</param>
/// <param name="mapper">Маппер для преобразования доменных моделей в DTO</param>
public class AnalyticsService(
    IRepository<Flight, int> flightRepository,
    IRepository<Passenger, int> passengerRepository,
    IRepository<Ticket, int> ticketRepository,
    IMapper mapper
) : IAnalyticsService
{
    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetTop5FlightsByPassengerCount()
    {
        var flights = await flightRepository.ReadAll();
        var tickets = await ticketRepository.ReadAll();

        var topFlights = flights
            .OrderByDescending(f => tickets.Count(t => t.FlightId == f.Id))
            .Take(5)
            .ToList();

        return mapper.Map<IList<FlightDto>>(topFlights);
    }

    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetFlightsWithMinimalDuration()
    {
        var flights = await flightRepository.ReadAll();
        var minDuration = flights.Min(f => f.Duration ?? TimeSpan.MinValue);

        var result = flights
            .Where(f => f.Duration == minDuration)
            .ToList();

        return mapper.Map<IList<FlightDto>>(result);
    }

    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetFlightsOfModelWithinPeriod(int aircraftModelId, DateTime startTime, DateTime endTime)
    {
        var flights = await flightRepository.ReadAll();

        var result = flights
            .Where(f => f.AircraftModelId == aircraftModelId
                        && f.DepartureDate >= startTime
                        && f.DepartureDate <= endTime)
            .ToList();

        return mapper.Map<IList<FlightDto>>(result);
    }

    /// <inheritdoc/>
    public async Task<IList<PassengerDto>> GetPassengersWithZeroBaggageByFlight(int flightId)
    {
        var tickets = await ticketRepository.ReadAll();
        var passengers = await passengerRepository.ReadAll();

        var passengerIds = tickets
            .Where(t => t.FlightId == flightId && t.BaggageWeight == 0)
            .Select(t => t.PassengerId)
            .Distinct()
            .ToList();

        var result = passengers
            .Where(p => passengerIds.Contains(p.Id))
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .ThenBy(p => p.Patronymic)
            .ToList();

        return mapper.Map<IList<PassengerDto>>(result);
    }

    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetFlightsBetweenAirports(string departurePoint, string arrivalPoint)
    {
        var flights = await flightRepository.ReadAll();

        var result = flights
            .Where(f => f.DeparturePoint == departurePoint && f.ArrivalPoint == arrivalPoint)
            .ToList();

        return mapper.Map<IList<FlightDto>>(result);
    }
}