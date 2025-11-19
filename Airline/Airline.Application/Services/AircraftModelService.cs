using Airline.Application.Contracts.AircraftFamilies;
using Airline.Application.Contracts.AircraftModels;
using Airline.Application.Contracts.Flights;
using Airline.Domain;
using Airline.Domain.Model.AircraftFamilies;
using Airline.Domain.Model.AircraftModels;
using Airline.Domain.Model.Flights;
using AutoMapper;

namespace Airline.Application.Services;

/// <summary>
/// Сервис для управления моделями самолётов и получения связанных семейств и рейсов
/// </summary>
/// <param name="modelRepository">Репозиторий для операций с сущностями моделей самолётов</param>
/// <param name="familyRepository">Репозиторий для операций с сущностями семейства самолётов</param>
/// <param name="flightRepository">Репозиторий для операций с сущностями рейсов</param>
/// <param name="mapper">Маппер для преобразования доменных моделей в DTO и обратно</param>
public class AircraftModelService(
    IRepository<AircraftModel, int> modelRepository,
    IRepository<AircraftFamily, int> familyRepository,
    IRepository<Flight, int> flightRepository,
    IMapper mapper
) : IAircraftModelService
{
    /// <inheritdoc/>
    public async Task<AircraftModelDto> Create(AircraftModelCreateUpdateDto dto)
    {
        var entity = mapper.Map<AircraftModel>(dto);

        var last = await modelRepository.ReadAll();
        entity.Id = last.Any() ? last.Max(x => x.Id) + 1 : 1;

        var result = await modelRepository.Create(entity);

        return mapper.Map<AircraftModelDto>(result);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int dtoId) =>
        await modelRepository.Delete(dtoId);

    /// <inheritdoc/>
    public async Task<AircraftModelDto?> Get(int dtoId)
    {
        var entity = await modelRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        return mapper.Map<AircraftModelDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<AircraftFamilyDto> GetAircraftFamily(int modelId)
    {
        var model = await modelRepository.Read(modelId) ?? throw new KeyNotFoundException($"Model with Id {modelId} not found");

        var family = await familyRepository.Read(model.FamilyId) ?? throw new KeyNotFoundException($"Family with Id {model.FamilyId} not found");

        return mapper.Map<AircraftFamilyDto>(family);
    }

    /// <inheritdoc/>
    public async Task<IList<AircraftModelDto>> GetAll() =>
        mapper.Map<IList<AircraftModelDto>>(await modelRepository.ReadAll());

    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetFlights(int modelId)
    {
        _ = await modelRepository.Read(modelId) ?? throw new KeyNotFoundException($"Model with Id {modelId} not found");

        var flights = await flightRepository.ReadAll();

        var result = flights
            .Where(f => f.AircraftModelId == modelId)
            .ToList();

        return mapper.Map<IList<FlightDto>>(result);
    }

    /// <inheritdoc/>
    public async Task<AircraftModelDto> Update(AircraftModelCreateUpdateDto dto, int dtoId)
    {
        var entity = await modelRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        mapper.Map(dto, entity);

        var result = await modelRepository.Update(entity);

        return mapper.Map<AircraftModelDto>(result);
    }
}