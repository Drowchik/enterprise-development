using Airline.Domain;
using Airline.Domain.Model.AircraftFamilies;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.EfCore.Repositories;

/// <summary>
/// Репозиторий для работы с коллекцией семейств самолётов
/// </summary>
public class AircraftFamilyRepository(AirlineDbContext context) : IRepository<AircraftFamily, int>
{
    /// <summary>
    /// Создать новое семейство самолётов
    /// </summary>
    /// <param name="entity">Семейство самолётов</param>
    /// <returns>Созданное семейство самолётов</returns>
    public async Task<AircraftFamily> Create(AircraftFamily entity)
    {
        var result = await context.Families.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удалить семейство самолётов по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор семейства</param>
    /// <returns>true если удаление прошло успешно иначе false</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Families.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Families.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Получить семейство самолётов по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор семейства</param>
    /// <returns>Семейство самолётов или null если не найдено</returns>
    public async Task<AircraftFamily?> Read(int entityId) =>
        await context.Families.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Получить все семейства самолётов
    /// </summary>
    /// <returns>Список всех семейств самолётов</returns>
    public async Task<IList<AircraftFamily>> ReadAll() =>
        await context.Families.ToListAsync();

    /// <summary>
    /// Обновить данные семейства самолётов
    /// </summary>
    /// <param name="entity">Семейство самолётов с новыми данными</param>
    /// <returns>Обновлённое семейство самолётов</returns>
    public async Task<AircraftFamily> Update(AircraftFamily entity)
    {
        context.Families.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}