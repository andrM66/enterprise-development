using BikeRent.Domain.Entities;
using BikeRent.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace BikeRent.Domain.Repositories;

public class ClientRepository(BikeRentDbContext context) : IRepository<Client, int>
{
    /// <summary>
    /// Delete sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(int id)
    {
        var oldValue = await GetByIdAsync(id);
        if (oldValue == null)
        {
            return false;
        }
        context.Remove(oldValue);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Client>> GetAllAsync() => await context.Clients.ToListAsync();

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public async Task<Client?> GetByIdAsync(int id) => await context.Clients.FirstOrDefaultAsync(cl => cl.Id == id);

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="entity">object</param>
    public async Task PostAsync(Client entity)
    {
        entity.BirthDate = DateTime.SpecifyKind(entity.BirthDate, DateTimeKind.Utc);
        context.Clients.Add(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="entity">object</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public async Task<bool> PutAsync(Client entity, int id)
    {
        var oldValue = await GetByIdAsync(id);
        if (oldValue == null)
        {
            return false;
        }
        oldValue.BirthDate = entity.BirthDate;
        oldValue.BirthDate = DateTime.SpecifyKind(oldValue.BirthDate, DateTimeKind.Utc);
        oldValue.FirstName = entity.FirstName;
        oldValue.SecondName = entity.SecondName;
        oldValue.Patronymic = entity.Patronymic;
        oldValue.PhoneNumber = entity.PhoneNumber;
        await context.SaveChangesAsync();
        return true;
    }
}
