using Airline.Domain;
using Airline.Domain.Model.AircraftModels;

namespace Airline.Infrastructure.EfCore.Repositories;

public class AircraftModelRepository(AirlineDbContext context) : IRepository<AircraftModel, int>
{
    public Task<AircraftModel> Create(AircraftModel entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<AircraftModel?> Read(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<AircraftModel>> ReadAll()
    {
        throw new NotImplementedException();
    }

    public Task<AircraftModel> Update(AircraftModel entity)
    {
        throw new NotImplementedException();
    }
}