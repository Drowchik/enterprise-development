using Airline.Domain.Model.AircraftFamilies;
using Airline.Domain.Model.AircraftModels;
using Airline.Domain.Model.Flights;
using Airline.Domain.Model.Passengers;
using Airline.Domain.Model.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.EfCore;
public class AirlineDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AircraftFamily> Families { get; set; }

    public DbSet<AircraftModel> Models { get; set; }

    public DbSet<Flight> Flights { get; set; }

    public DbSet<Passenger> Passengers { get; set; }

    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

}
