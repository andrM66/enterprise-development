namespace BikeRent.Domain.Repositories;

public class BikeTypeRepository : IRepository<BikeType, int>
{
    private readonly List<BikeType> _bikeTypes = [];
    private int _lastId = 0;

    /// <summary>
    /// Delete sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        var bikeType = GetById(id);
        if (bikeType == null)
        {
            return false;
        }
        _bikeTypes.Remove(bikeType);
        return true;
    }

    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    public IEnumerable<BikeType> GetAll() => _bikeTypes;

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public BikeType? GetById(int id) => _bikeTypes.Find(x => x.Id == id);

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="entity">object</param>
    public void Post(BikeType entity)
    {
        entity.Id = ++_lastId;
        _bikeTypes.Add(entity);
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="entity">object</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public bool Put(BikeType entity, int id)
    {
        var oldValue = GetById(id);
        if(oldValue == null)
        {
            return false;
        }
        oldValue.Name = entity.Name;
        oldValue.Price = entity.Price;
        return true;
    }
}
