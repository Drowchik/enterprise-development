using Airline.Domain;
using Airline.Domain.Model.Passengers;

namespace Airline.Infrastructure.EfCore.Repositories;

public class PassengerRepository(AirlineDbContext context) : IRepository<Passenger, int>
{
    public Task<Passenger> Create(Passenger entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<Passenger?> Read(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Passenger>> ReadAll()
    {
        throw new NotImplementedException();
    }

    public Task<Passenger> Update(Passenger entity)
    {
        throw new NotImplementedException();
    }
}