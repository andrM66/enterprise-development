namespace BikeRent.Domain.Repositories;

public class ClientRepository : IRepository<Client, int>
{
    private readonly List<Client> _clients = [];
    public bool Delete(int id)
    {
        var client = GetById(id);
        if (client == null)
        {
            return false;
        }
        _clients.Remove(client);
        return true;
    }

    public IEnumerable<Client> GetAll() => _clients;

    public Client? GetById(int id) => _clients.Find(x => x.Id == id);

    public void Post(Client entity)
    {
        entity.Id = _clients.Count;
        _clients.Add(entity);
    }

    public bool Put(Client entity, int id)
    {
        var oldValue = GetById(id);
        if (oldValue == null)
        {
            return false;
        }
        oldValue.BirthDate = entity.BirthDate;
        oldValue.PhoneNumber = entity.PhoneNumber;
        oldValue.FirstName = entity.FirstName;
        oldValue.SecondName = entity.SecondName;
        oldValue.Patronymic = entity.Patronymic;
        return true;
    }
}
