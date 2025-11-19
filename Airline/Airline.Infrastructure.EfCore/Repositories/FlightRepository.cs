using Airline.Domain;
using Airline.Domain.Model.Flights;

namespace Airline.Infrastructure.EfCore.Repositories;

public class FlightRepository(AirlineDbContext context) : IRepository<Flight, int>
{
    public Task<Flight> Create(Flight entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<Flight?> Read(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Flight>> ReadAll()
    {
        throw new NotImplementedException();
    }

    public Task<Flight> Update(Flight entity)
    {
        throw new NotImplementedException();
    }
}