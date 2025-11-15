using Airline.Domain;
using Airline.Domain.Model.AircraftFamilies;

namespace Airline.Infrastructure.EfCore.Repositories;

public class AircraftFamilyRepository(AirlineDbContext context) : IRepository<AircraftFamily, int>
{
    public Task<AircraftFamily> Create(AircraftFamily entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<AircraftFamily?> Read(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<AircraftFamily>> ReadAll()
    {
        throw new NotImplementedException();
    }

    public Task<AircraftFamily> Update(AircraftFamily entity)
    {
        throw new NotImplementedException();
    }
}