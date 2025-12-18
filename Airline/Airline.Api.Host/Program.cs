using Airline.Api.Host.Grpc;
using Airline.Application;
using Airline.Application.Contracts;
using Airline.Application.Contracts.AircraftFamilies;
using Airline.Application.Contracts.AircraftModels;
using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;
using Airline.Application.Contracts.Protos;
using Airline.Application.Contracts.Tickets;
using Airline.Application.Services;
using Airline.Domain;
using Airline.Domain.Data;
using Airline.Domain.Model.AircraftFamilies;
using Airline.Domain.Model.AircraftModels;
using Airline.Domain.Model.Flights;
using Airline.Domain.Model.Passengers;
using Airline.Domain.Model.Tickets;
using Airline.Infrastructure.EfCore;
using Airline.Infrastructure.EfCore.Repositories;
using Airline.ServiceDefaults;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddSingleton<DataSeeder>();


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AirlineProfile());
    config.AddProfile(new AirlineGrpcProfile());
});

builder.Services.AddTransient<IRepository<AircraftFamily, int>, AircraftFamilyRepository>();
builder.Services.AddTransient<IRepository<AircraftModel, int>, AircraftModelRepository>();
builder.Services.AddTransient<IRepository<Flight, int>, FlightRepository>();
builder.Services.AddTransient<IRepository<Passenger, int>, PassengerRepository>();
builder.Services.AddTransient<IRepository<Ticket, int>, TicketRepository>();

builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
builder.Services.AddScoped<IAircraftFamilyService, AircraftFamilyService>();
builder.Services.AddScoped<IAircraftModelService, AircraftModelService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies()
        .Where(a => a.GetName().Name!.StartsWith("Airline"))
        .Distinct();

    foreach (var assembly in assemblies)
    {
        var xmlFile = $"{assembly.GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            c.IncludeXmlComments(xmlPath);
    }
});

builder.AddMongoDBClient("airlineClient");

builder.Services.AddDbContext<AirlineDbContext>((services, o) =>
{
    var db = services.GetRequiredService<IMongoDatabase>();
    o.UseMongoDB(db.Client, db.DatabaseNamespace.DatabaseName);
});

builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = builder.Environment.IsDevelopment();
});


builder.Services.AddGrpcClient<TicketGeneratorGrpcService.TicketGeneratorGrpcServiceClient>(o =>
{
    var addr = builder.Configuration["TicketGenerator:GrpcAddress"]
               ?? throw new InvalidOperationException("TicketGenerator:GrpcAddress is not configured");
    o.Address = new Uri(addr);
});

builder.Services.AddHostedService<AirlineGrpcClient>();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AirlineDbContext>();
var dataSeed = scope.ServiceProvider.GetRequiredService<DataSeeder>();

if (!dbContext.Families.Any())
{
    foreach (var family in dataSeed.Families)
        await dbContext.Families.AddAsync(family);

    foreach (var model in dataSeed.Models)
        await dbContext.Models.AddAsync(model);

    foreach (var flight in dataSeed.Flights)
        await dbContext.Flights.AddAsync(flight);

    foreach (var passenger in dataSeed.Passengers)
        await dbContext.Passengers.AddAsync(passenger);

    foreach (var ticket in dataSeed.Tickets)
        await dbContext.Tickets.AddAsync(ticket);

    await dbContext.SaveChangesAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();