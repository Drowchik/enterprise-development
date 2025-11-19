using Airline.Domain;
using Airline.Domain.Model.AircraftModels;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.EfCore.Repositories;

/// <summary>
/// Репозиторий для работы с коллекцией моделей самолётов
/// </summary>
public class AircraftModelRepository(AirlineDbContext context) : IRepository<AircraftModel, int>
{
    /// <summary>
    /// Создать новую модель самолётов
    /// </summary>
    /// <param name="entity">Модель самолётов</param>
    /// <returns>Созданная модель самолётов</returns>
    public async Task<AircraftModel> Create(AircraftModel entity)
    {
        var result = await context.Models.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удалить модель самолётов по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор модели</param>
    /// <returns>true если удаление прошло успешно иначе false</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Models.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Models.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Получить модель самолётов по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор модели</param>
    /// <returns>Семейство самолётов или null если не найдено</returns>
    public async Task<AircraftModel?> Read(int entityId) =>
        await context.Models.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Получить все модели самолётов
    /// </summary>
    /// <returns>Список всех моделей самолётов</returns>
    public async Task<IList<AircraftModel>> ReadAll() =>
        await context.Models.ToListAsync();

    /// <summary>
    /// Обновить данные модели самолётов
    /// </summary>
    /// <param name="entity">Модель самолётов с новыми данными</param>
    /// <returns>Обновлённая модель самолётов</returns>
    public async Task<AircraftModel> Update(AircraftModel entity)
    {
        context.Models.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}