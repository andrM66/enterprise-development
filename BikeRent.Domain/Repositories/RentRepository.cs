using BikeRent.Domain.Entities;
using BikeRent.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace BikeRent.Domain.Repositories;

public class RentRepository(BikeRentDbContext context) : IRepository<Rent, int>
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
    public async Task<IEnumerable<Rent>> GetAllAsync() => await context.Rents.ToListAsync();

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public async Task<Rent>? GetByIdAsync(int id) => await context.Rents.FirstOrDefaultAsync(r => r.Id == id);

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="entity">object</param>
    public async Task PostAsync(Rent entity)
    {
        context.Rents.Add(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="entity">object</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public async Task<bool> PutAsync(Rent entity, int id)
    {
        var oldValue = await GetByIdAsync(id);
        if (oldValue == null)
        {
            return false;
        }
        oldValue.Begin = entity.Begin;
        oldValue.End = entity.End;
        oldValue.BikeId = entity.BikeId;
        oldValue.ClientId = entity.ClientId;
        await context.SaveChangesAsync();
        return true;
    }
}
