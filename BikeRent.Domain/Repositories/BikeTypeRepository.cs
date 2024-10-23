
namespace BikeRent.Domain.Repositories;

public class BukeTypeRepository : IRepository<BikeType, int>
{
    private readonly List<BikeType> _bikeTypes = [];
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

    public IEnumerable<BikeType> GetAll() => _bikeTypes;

    public BikeType? GetById(int id) => _bikeTypes.Find(x => x.Id == id);

    public void Post(BikeType entity)
    {
        entity.Id = _bikeTypes.Count;
        _bikeTypes.Add(entity);
    }

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
