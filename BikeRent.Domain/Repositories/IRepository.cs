namespace BikeRent.Domain.Repositories;
public interface IRepository<T, Tid>
{
    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public T? GetById(int id);

    /// <summary>
    /// Delete sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    public bool Delete(int id);

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="entity">object</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public bool Put(T entity, int id);

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="entity">object</param>
    public void Post(T entity);
}
