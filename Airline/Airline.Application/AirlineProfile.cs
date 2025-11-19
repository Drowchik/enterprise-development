using Airline.Application.Contracts.AircraftFamilies;
using Airline.Application.Contracts.AircraftModels;
using Airline.Application.Contracts.Flights;
using Airline.Application.Contracts.Passengers;
using Airline.Application.Contracts.Tickets;
using Airline.Domain.Model.AircraftFamilies;
using Airline.Domain.Model.AircraftModels;
using Airline.Domain.Model.Flights;
using Airline.Domain.Model.Passengers;
using Airline.Domain.Model.Tickets;
using AutoMapper;

namespace Airline.Application;

/// <summary>
/// Профиль AutoMapper для авиакомпании
/// </summary>
public class AirlineProfile : Profile
{
    /// <summary>
    /// Конструктор профиля, создающий связи между Entity и Dto классами
    /// </summary>
    public AirlineProfile()
    {
        CreateMap<AircraftFamily, AircraftFamilyDto>();
        CreateMap<AircraftFamilyCreateUpdateDto, AircraftFamily>();

        CreateMap<AircraftModel, AircraftModelDto>();
        CreateMap<AircraftModelCreateUpdateDto, AircraftModel>();

        CreateMap<Flight, FlightDto>();
        CreateMap<FlightCreateUpdateDto, Flight>();

        CreateMap<Passenger, PassengerDto>();
        CreateMap<PassengerCreateUpdateDto, Passenger>();

        CreateMap<Ticket, TicketDto>();
        CreateMap<TicketCreateUpdateDto, Ticket>();
    }
}