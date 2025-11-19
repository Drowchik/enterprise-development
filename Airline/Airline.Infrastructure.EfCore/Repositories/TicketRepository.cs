using Airline.Domain;
using Airline.Domain.Model.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.EfCore.Repositories;

/// <summary>
/// Репозиторий для работы с коллекцией билетов
/// </summary>
public class TicketRepository(AirlineDbContext context) : IRepository<Ticket, int>
{
    /// <summary>
    /// Создать новый билет
    /// </summary>
    /// <param name="entity">Билет</param>
    /// <returns>Созданный билет</returns>
    public async Task<Ticket> Create(Ticket entity)
    {
        var result = await context.Tickets.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Удалить билет по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор билета</param>
    /// <returns>true если удаление прошло успешно иначе false</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Tickets.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Tickets.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Получить билет по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор билета</param>
    /// <returns>Билет или null если не найден</returns>
    public async Task<Ticket?> Read(int entityId) =>
        await context.Tickets.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Получить все билеты
    /// </summary>
    /// <returns>Список всех билетов</returns>
    public async Task<IList<Ticket>> ReadAll() =>
        await context.Tickets.ToListAsync();

    /// <summary>
    /// Обновить данные билета
    /// </summary>
    /// <param name="entity">Билет с новыми данными</param>
    /// <returns>Обновлённый билет</returns>
    public async Task<Ticket> Update(Ticket entity)
    {
        context.Tickets.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}