namespace BikeRent.Domain.Repositories;
public interface IRepository<T, TId>
{
    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(TId id);

    /// <summary>
    /// Delete sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    Task<bool> DeleteAsync(TId id);

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="entity">object</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    Task<bool> PutAsync(T entity, TId id);

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="entity">object</param>
    Task  PostAsync(T entity);
}
