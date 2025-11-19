using Airline.Domain;
using Airline.Domain.Model.Flights;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.EfCore.Repositories;

/// <summary>
/// Репозиторий для работы с коллекцией авиарейсов
/// </summary>
public class FlightRepository(AirlineDbContext context) : IRepository<Flight, int>
{
    /// <summary>
    /// Создать новый авиарейс
    /// </summary>
    /// <param name="entity">Авиарейс</param>
    /// <returns>Созданный авиарейс</returns>
    public async Task<Flight> Create(Flight entity)
    {
        var result = await context.Flights.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удалить авиарейс по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор рейса</param>
    /// <returns>true если удаление прошло успешно иначе false</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Flights.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Flights.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Получить авиарейс по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор рейса</param>
    /// <returns>Авиарейс или null если не найден</returns>
    public async Task<Flight?> Read(int entityId) =>
        await context.Flights.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Получить все авиарейсы
    /// </summary>
    /// <returns>Список всех авиарейсов</returns>
    public async Task<IList<Flight>> ReadAll() =>
        await context.Flights.ToListAsync();

    /// <summary>
    /// Обновить данные авиарейса
    /// </summary>
    /// <param name="entity">Авиарейс с новыми данными</param>
    /// <returns>Обновлённый авиарейс</returns>
    public async Task<Flight> Update(Flight entity)
    {
        context.Flights.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}