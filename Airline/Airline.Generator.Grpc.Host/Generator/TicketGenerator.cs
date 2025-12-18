using Airline.Application.Contracts.Tickets;
using Bogus;

namespace Airline.Generator.Grpc.Host.Generator;

/// <summary>
/// Генератор тестовых TicketCreateUpdateDto на основе Bogus
/// </summary>
public static class TicketGenerator
{
    /// <summary>
    /// Генерация списка DTO для создания или обновления билетов
    /// </summary>
    public static IList<TicketCreateUpdateDto> Generate(int count)
    {
        var faker = new Faker();

        var list = new List<TicketCreateUpdateDto>(count);

        for (var i = 0; i < count; i++)
        {
            var flightId = faker.Random.Int(1, 20);
            var passengerId = faker.Random.Int(1, 20);

            var seatNumber = $"{faker.Random.Int(1, 60)}{faker.Random.Char('A', 'F')}";

            var hasHandLuggage = faker.Random.Bool();

            var baggageWeight = Math.Round(faker.Random.Double(0, 50), 1);

            list.Add(new TicketCreateUpdateDto(
                FlightId: flightId,
                PassengerId: passengerId,
                SeatNumber: seatNumber,
                HasHandLuggage: hasHandLuggage,
                BaggageWeight: baggageWeight
            ));
        }

        return list;
    }
}