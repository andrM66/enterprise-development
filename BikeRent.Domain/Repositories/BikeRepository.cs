namespace BikeRent.Domain.Repositories;

public class BikeRepository : IRepository<Bike, int>
{
    private readonly List<Bike> _bikes = [];

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

    public IEnumerable<Bike> GetAll() => _bikes;

    public Bike? GetById(int id) => _bikes.Find(x => x.Id == id);

    public void Post(Bike entity)
    {
        entity.Id = _bikes.Count;
        _bikes.Add(entity);
    }

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
