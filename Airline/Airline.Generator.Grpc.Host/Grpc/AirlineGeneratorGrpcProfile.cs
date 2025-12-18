using Airline.Application.Contracts.Protos;
using Airline.Application.Contracts.Tickets;
using AutoMapper;

namespace Airline.Generator.Grpc.Host.Grpc;

/// <summary>
/// Профиль AutoMapper для преобразования контрактных DTO в protobuf сообщения gRPC
/// </summary>
public sealed class AirlineGeneratorGrpcProfile : Profile
{
    /// <summary>
    /// Настройка правил маппинга между DTO приложения и сообщениями gRPC
    /// </summary>
    public AirlineGeneratorGrpcProfile()
    {
        CreateMap<TicketCreateUpdateDto, TicketCreateUpdateDtoMessage>();
    }
}