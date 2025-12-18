using Airline.Application.Contracts.Protos;
using Airline.Application.Contracts.Tickets;
using AutoMapper;

namespace Airline.Api.Host.Grpc;

/// <summary>
/// Профиль AutoMapper для преобразования protobuf сообщений gRPC в контрактные DTO приложения
/// </summary>
public class AirlineGrpcProfile : Profile
{
    /// <summary>
    /// Настройка правил маппинга между сообщениями gRPC и DTO используемыми в прикладном слое
    /// </summary>
    public AirlineGrpcProfile()
    {
        CreateMap<TicketCreateUpdateDtoMessage, TicketCreateUpdateDto>();
    }
}