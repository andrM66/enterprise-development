namespace BikeRent.Domain.Repositories;

public class BikeRepository : IRepository<Bike, int>
{
    private readonly List<Bike> _bikes = [];
    private int _last_id = 0;

    /// <summary>
    /// Delete sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        var bike = GetById(id);
        if (bike ==  null)
        {
            return false;
        }
        _bikes.Remove(bike);
        return true;
    }

    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Bike> GetAll() => _bikes;

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public Bike? GetById(int id) => _bikes.Find(x => x.Id == id);

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="entity">object</param>
    public void Post(Bike entity)
    {
        _last_id++;
        entity.Id = _last_id;
        _bikes.Add(entity);
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="entity">object</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public bool Put(Bike entity, int id)
    {
        var oldValue = GetById(id);
        if(oldValue == null)
        {
            return false;
        }
        oldValue.TypeId = entity.TypeId;
        oldValue.Model = entity.Model;
        oldValue.Color = entity.Color;
        return true;
    }
}
