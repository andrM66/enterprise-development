namespace BikeRent.Domain.Repositories;

internal interface ClientRepository
{
    public IEnumerable<Client> GetClients();
    public Client? GetClient(int id);
    public void PostClient(Client client);
    public bool PutClient(int id, Client client);
    public bool DeleteClient(int id);
}
