using Airline.Domain;
using Airline.Domain.Model.Passengers;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.EfCore.Repositories;

/// <summary>
/// Репозиторий для работы с коллекцией пассажиров
/// </summary>
public class PassengerRepository(AirlineDbContext context) : IRepository<Passenger, int>
{
    /// <summary>
    /// Создать нового пассажира
    /// </summary>
    /// <param name="entity">Пассажир</param>
    /// <returns>Созданный пассажир</returns>
    public async Task<Passenger> Create(Passenger entity)
    {
        var result = await context.Passengers.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удалить пассажира по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор пассажира</param>
    /// <returns>true если удаление прошло успешно иначе false</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Passengers.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Passengers.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Получить пассажира по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор пассажира</param>
    /// <returns>Пассажир или null если не найден</returns>
    public async Task<Passenger?> Read(int entityId) =>
        await context.Passengers.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Получить всех пассажиров
    /// </summary>
    /// <returns>Список всех пассажиров</returns>
    public async Task<IList<Passenger>> ReadAll() =>
        await context.Passengers.ToListAsync();

    /// <summary>
    /// Обновить данные пассажира
    /// </summary>
    /// <param name="entity">Пассажир с новыми данными</param>
    /// <returns>Обновлённый пассажир</returns>
    public async Task<Passenger> Update(Passenger entity)
    {
        context.Passengers.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}