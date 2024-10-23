
namespace BikeRent.Domain.Repositories;

public class RentRepository : IRepository<Rent, int>
{
    private readonly List<Rent> _rents = [];
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

    public IEnumerable<Rent> GetAll() => _rents;

    public Rent? GetById(int id) => _rents.Find(x => x.Id == id);

    public void Post(Rent entity)
    {
        entity.Id = _rents.Count;
        _rents.Add(entity);
    }

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
