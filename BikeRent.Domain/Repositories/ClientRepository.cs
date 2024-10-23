namespace BikeRent.Domain.Repositories;

public class ClientRepository : IRepository<Client, int>
{
    private readonly List<Client> _clients = [];
    private int _last_id = 0;

    /// <summary>
    /// Delete sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
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

    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Client> GetAll() => _clients;

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public Client? GetById(int id) => _clients.Find(x => x.Id == id);

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="entity">object</param>
    public void Post(Client entity)
    {
        _last_id++; 
        entity.Id = _last_id;
        _clients.Add(entity);
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="entity">object</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
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
