using Airline.Domain.Model.AircraftFamilies;
using Airline.Domain.Model.AircraftModels;
using Airline.Domain.Model.Flights;
using Airline.Domain.Model.Passengers;
using Airline.Domain.Model.Tickets;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Airline.Infrastructure.EfCore;

/// <summary>
/// Контекст базы данных авиакомпании
/// </summary>
public class AirlineDbContext(DbContextOptions options) : DbContext(options)
{
    /// <summary>
    /// Коллекция семейств самолётов
    /// </summary>
    public DbSet<AircraftFamily> Families { get; set; }

    /// <summary>
    /// Коллекция моделей самолётов
    /// </summary>
    public DbSet<AircraftModel> Models { get; set; }

    /// <summary>
    /// Коллекция рейсов
    /// </summary>
    public DbSet<Flight> Flights { get; set; }

    /// <summary>
    /// Коллекция пассажиров
    /// </summary>
    public DbSet<Passenger> Passengers { get; set; }

    /// <summary>
    /// Коллекция билетов
    /// </summary>
    public DbSet<Ticket> Tickets { get; set; }

    /// <summary>
    /// Настройка сущностей и их связей
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AircraftFamily>(builder =>
        {
            builder.ToCollection("aircraft_families");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).HasElementName("_id");
            builder.Property(f => f.Name).HasElementName("name");
            builder.Property(f => f.Manufacturer).HasElementName("manufacturer");

            builder.HasMany(f => f.Models)
                    .WithOne(m => m.Family)
                    .HasForeignKey(m => m.FamilyId);
        });

        modelBuilder.Entity<AircraftModel>(builder =>
        {
            builder.ToCollection("aircraft_models");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).HasElementName("_id");
            builder.Property(m => m.Name).HasElementName("name");
            builder.Property(m => m.FlightRange).HasElementName("flight_range");
            builder.Property(m => m.PassengerCapacity).HasElementName("passenger_capacity");
            builder.Property(m => m.CargoCapacity).HasElementName("cargo_capacity");
            builder.Property(m => m.FamilyId).HasElementName("family_id");

            builder.HasMany(m => m.Flights)
                    .WithOne(f => f.AircraftModel)
                    .HasForeignKey(f => f.AircraftModelId);
        });

        modelBuilder.Entity<Passenger>(builder =>
        {
            builder.ToCollection("passengers");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasElementName("_id");
            builder.Property(p => p.PassportNumber).HasElementName("passport_number");
            builder.Property(p => p.FirstName).HasElementName("first_name");
            builder.Property(p => p.LastName).HasElementName("last_name");
            builder.Property(p => p.Patronymic).HasElementName("patronymic");

            builder.HasMany(p => p.Tickets)
               .WithOne(t => t.Passenger)
               .HasForeignKey(t => t.PassengerId);
        });

        modelBuilder.Entity<Flight>(builder =>
        {
            builder.ToCollection("flights");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).HasElementName("_id");
            builder.Property(f => f.Code).HasElementName("code");
            builder.Property(f => f.DeparturePoint).HasElementName("departure_point");
            builder.Property(f => f.ArrivalPoint).HasElementName("arrival_point");
            builder.Property(f => f.DepartureDate).HasElementName("departure_date");
            builder.Property(f => f.ArrivalDate).HasElementName("arrival_date");
            builder.Property(f => f.Duration).HasElementName("duration");
            builder.Property(f => f.AircraftModelId).HasElementName("aircraft_model_id");

            builder.HasMany(f => f.Tickets)
               .WithOne(t => t.Flight)
               .HasForeignKey(t => t.FlightId);
        });

        modelBuilder.Entity<Ticket>(builder =>
        {
            builder.ToCollection("tickets");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasElementName("_id");
            builder.Property(t => t.SeatNumber).HasElementName("seat_number");
            builder.Property(t => t.HasHandLuggage).HasElementName("has_hand_luggage");
            builder.Property(t => t.BaggageWeight).HasElementName("baggage_weight");
            builder.Property(t => t.FlightId).HasElementName("flight_id");
            builder.Property(t => t.PassengerId).HasElementName("passenger_id");
        });
    }
}
