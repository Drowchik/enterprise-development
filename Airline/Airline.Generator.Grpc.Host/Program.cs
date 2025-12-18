using Airline.Generator.Grpc.Host.Grpc;
using Airline.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AirlineGeneratorGrpcProfile());
});

builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = builder.Environment.IsDevelopment();
});

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGrpcService<AirlineGrpcGeneratorService>();

app.Run();
