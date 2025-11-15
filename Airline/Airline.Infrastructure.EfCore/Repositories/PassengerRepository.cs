using Airline.Domain;
using Airline.Domain.Model.Passengers;

namespace Airline.Infrastructure.EfCore.Repositories;

public class PassengerRepository(AirlineDbContext context) : IRepository<Passenger, int>
{
    public Task<Passenger> Create(Passenger entity)
    {
        throw new NotImplementedException();
    }

    public Task<Passenger> Update(Passenger entity)
    {
        throw new NotImplementedException();
    }

    Task<Passenger?> IRepository<Passenger, int>.Read(int entityId)
    {
        throw new NotImplementedException();
    }

    Task<IList<Passenger>> IRepository<Passenger, int>.ReadAll()
    {
        throw new NotImplementedException();
    }
}