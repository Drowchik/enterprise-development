using Airline.Domain;
using Airline.Domain.Model.Tickets;

namespace Airline.Infrastructure.EfCore.Repositories;

public class TicketRepository(AirlineDbContext context) : IRepository<Ticket, int>
{
    public Task<Ticket> Create(Ticket entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<Ticket?> Read(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Ticket>> ReadAll()
    {
        throw new NotImplementedException();
    }

    public Task<Ticket> Update(Ticket entity)
    {
        throw new NotImplementedException();
    }
}