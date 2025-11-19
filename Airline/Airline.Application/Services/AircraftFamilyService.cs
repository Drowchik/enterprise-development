using Airline.Application.Contracts.AircraftFamilies;
using Airline.Application.Contracts.AircraftModels;
using Airline.Domain;
using Airline.Domain.Model.AircraftFamilies;
using Airline.Domain.Model.AircraftModels;
using AutoMapper;

namespace Airline.Application.Services;

/// <summary>
/// Сервис для управления семействами самолётов и получения связанных моделей
/// </summary>
/// <param name="familyRepository">Репозиторий для операций с сущностями семейства самолётов</param>
/// <param name="modelRepository">Репозиторий для операций с сущностями моделей самолётов</param>
/// <param name="mapper">Маппер для преобразования доменных моделей в DTO и обратно</param>
public class AircraftFamilyService(
    IRepository<AircraftFamily, int> familyRepository, 
    IRepository<AircraftModel, int> modelRepository, 
    IMapper mapper
) : IAircraftFamilyService
{
    /// <inheritdoc/>
    public async Task<AircraftFamilyDto> Create(AircraftFamilyCreateUpdateDto dto)
    {
        var entity = mapper.Map<AircraftFamily>(dto);

        var last = await familyRepository.ReadAll();
        entity.Id = last.Any() ? last.Max(x => x.Id) + 1 : 1;

        var result = await familyRepository.Create(entity);

        return mapper.Map<AircraftFamilyDto>(result);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int dtoId) =>
        await familyRepository.Delete(dtoId);

    /// <inheritdoc/>
    public async Task<AircraftFamilyDto?> Get(int dtoId)
    {
        var entity = await familyRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        return mapper.Map<AircraftFamilyDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IList<AircraftModelDto>> GetAircraftModels(int familyId)
    {
        _ = await familyRepository.Read(familyId) ?? throw new KeyNotFoundException($"Family with Id {familyId} not found");

        var models = await modelRepository.ReadAll();

        var relatedModels = models
            .Where(m => m.FamilyId == familyId)
            .ToList();

        return mapper.Map<IList<AircraftModelDto>>(relatedModels);
    }

    /// <inheritdoc/>
    public async Task<IList<AircraftFamilyDto>> GetAll() =>
        mapper.Map<IList<AircraftFamilyDto>>(await familyRepository.ReadAll());

    /// <inheritdoc/>
    public async Task<AircraftFamilyDto> Update(AircraftFamilyCreateUpdateDto dto, int dtoId)
    {
        var entity = await familyRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        mapper.Map(dto, entity);

        var result = await familyRepository.Update(entity);

        return mapper.Map<AircraftFamilyDto>(result);
    }
}