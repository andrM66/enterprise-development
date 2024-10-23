using System.Runtime.CompilerServices;

namespace BikeRent.Domain.Repositories;

public class RentRepository : IRepository<Rent, int>
{
    private readonly List<Rent> _rents = [];
    private int _last_id = 0;

    /// <summary>
    /// Delete sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        var rent = GetById(id);
        if(rent == null)
        {
            return false;
        }
        _rents.Remove(rent);
        return true;
    }

    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Rent> GetAll() => _rents;

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public Rent? GetById(int id) => _rents.Find(x => x.Id == id);

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="entity">object</param>
    public void Post(Rent entity)
    {
        _last_id++;
        entity.Id = _last_id;
        _rents.Add(entity);
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="entity">object</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public bool Put(Rent entity, int id)
    {
        var oldValue = GetById(id);
        if (oldValue == null)
        {
            return false;
        }
        oldValue.ClientId = entity.ClientId;
        oldValue.BikeId = entity.BikeId;
        oldValue.Begin = entity.Begin;
        oldValue.End = entity.End;
        return true;
    }
}
