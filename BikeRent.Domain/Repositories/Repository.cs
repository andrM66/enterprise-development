

namespace BikeRent.Domain.Repositories;

public class Repository : ClientRepository, BikeRepoitory, BikeTypeRepository, RentRepository
{
    private readonly List<Client> _clients = [];

    private readonly List<Bike> _bikes = [];

    private readonly List<BikeType> _biketypes = [];

    private readonly List<Rent> _rents = [];

    public bool DeleteBike(int id)
    {
        var bike = GetBike(id);
        if (bike == null)
        {
            return false;
        }
        _bikes.Remove(bike);
        return true;
    }

    public bool DeleteBikeType(int id)
    {
        var biketype = GetBikeType(id);
        if(biketype == null)
        {
            return false;
        }
        _biketypes.Remove(biketype);
        return true;
    }

    public bool DeleteClient(int id)
    {
        var client = GetClient(id);
        if(client == null)
        {
            return false;
        }
        _clients.Remove(client);
        return true;
    }

    public bool DeleteRent(int id)
    {
        var rent = GetRent(id);
        if(rent == null)
        {
            return false;
        }
        _rents.Remove(rent);
        return true;
    }

    public Bike? GetBike(int id) => _bikes.Find(b => b.Id == id);

    public IEnumerable<Bike> GetBikes() => _bikes;

    public BikeType? GetBikeType(int id) => _biketypes.Find(bt => bt.Id == id);

    public IEnumerable<BikeType> GetBikeTypes() => _biketypes;

    public Client? GetClient(int id) => _clients.Find(c => c.Id == id);

    public IEnumerable<Client> GetClients() => _clients;

    public Rent? GetRent(int id) => _rents.Find(r => r.Id == id);

    public IEnumerable<Rent> GetRents() => _rents;

    public void PostBike(Bike bike)
    {
        bike.Id = _bikes.Count;
        _bikes.Add(bike);
    }

    public void PostBikeType(BikeType biketype)
    {
        biketype.Id = _biketypes.Count;
        _biketypes.Add(biketype);
    }

    public void PostClient(Client client)
    {
        client.Id = _clients.Count;
        _clients.Add(client);
    }

    public void PostRent(Rent rent)
    {
        rent.Id = _rents.Count;
        _rents.Add(rent);
    }

    public bool PutBike(int id, Bike bike)
    {
        var oldValue = GetBike(id);
        if (oldValue == null)
        {
            return false;
        }
        oldValue.Model = bike.Model;
        oldValue.Color = bike.Color;
        oldValue.TypeId = bike.TypeId;
        return true;
    }

    public bool PutBikeType(int id, BikeType bikeType)
    {
        var oldValue = GetBikeType(id);
        if (oldValue == null)
        {
            return false;
        }
        oldValue.Price = bikeType.Price;
        oldValue.Name = bikeType.Name;
        return true;
    }

    public bool PutClient(int id, Client client)
    {
        var oldValue = GetClient(id);
        if(oldValue == null)
        {
            return false;
        }
        oldValue.FirstName = client.FirstName;
        oldValue.SecondName = client.SecondName;
        oldValue.Patronymic = client.Patronymic;
        oldValue.PhoneNumber = client.PhoneNumber;
        return true;
    }

    public bool PutRent(int id, Rent rent)
    {
        var oldValue = GetRent(id);
        if(oldValue == null )
        {
            return false;
        }
        oldValue.ClientId = rent.ClientId;
        oldValue.BikeId = rent.BikeId;
        oldValue.Begin = rent.Begin;
        oldValue.End = rent.End;
        return true;
    }
}

