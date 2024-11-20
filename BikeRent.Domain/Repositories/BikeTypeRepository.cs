using BikeRent.Domain.Entities;
using BikeRent.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace BikeRent.Domain.Repositories;

public class BikeTypeRepository(BikeRentDbContext context) : IRepository<BikeType, int>
{
    /// <summary>
    /// Delete sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(int id)
    {
        var oldValue = await GetByIdAsync(id);
        if(oldValue == null)
        {
            return false;
        }
        context.BikeTypes.Remove(oldValue);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<BikeType>> GetAllAsync() => await context.BikeTypes.ToListAsync();

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public async Task<BikeType>? GetByIdAsync(int id) =>  await context.BikeTypes.FirstOrDefaultAsync(bt => bt.Id == id);

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="entity">object</param>
    public async Task PostAsync(BikeType entity)
    {
        context.BikeTypes.Add(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="entity">object</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public async Task<bool> PutAsync(BikeType entity, int id)
    {
        var oldValue = await GetByIdAsync(id);
        if (oldValue == null)
        {
            return false;
        }
        oldValue.Price = entity.Price;
        oldValue.Name = entity.Name;
        await context.SaveChangesAsync();
        return true;
    }
}
