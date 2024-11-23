using BikeRent.Domain.Entities;
using BikeRent.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace BikeRent.Domain.Repositories;

public class BikeRepository(BikeRentDbContext context) : IRepository<Bike, int>
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
        context.Bikes.Remove(oldValue);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Bike>> GetAllAsync() => await context.Bikes.ToListAsync();

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public async Task<Bike?> GetByIdAsync(int id) => await context.Bikes.FirstOrDefaultAsync(b => b.Id == id);

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="entity">object</param>
    public async Task PostAsync(Bike entity)
    {
        context.Bikes.Add(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="entity">object</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public async Task<bool> PutAsync(Bike entity, int id)
    {
        var oldValue = await GetByIdAsync(id);
        if(oldValue == null)
        {
            return false;
        }
        oldValue.TypeId = entity.TypeId;
        oldValue.Color = entity.Color;
        oldValue.Model = entity.Model;
        await context.SaveChangesAsync();
        return true;
    }
}
