namespace BikeRent.WebClient.Api;

public class BikeRentApiWrapper(IConfiguration configuration) : IBikeRentApiWrapper
{
    public readonly BikeRentApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task<IEnumerable<Bike>> GetAllBikes() => [.. await _client.BikeAllAsync()];
    public async Task<IEnumerable<BikeType>> GetAllBikeTypes() => [.. await _client.BikeTypeAllAsync()];
    public async Task<IEnumerable<Client>> GetAllClients() => [.. await _client.ClientAllAsync()];
    public async Task<IEnumerable<Rent>> GetAllRents() => [.. await _client.RentAllAsync()];

    public async Task PostBike(BikeDto entity) => await _client.BikePOSTAsync(entity);
    public async Task PostBikeType(BikeTypeDto entity) => await _client.BikeTypePOSTAsync(entity);
    public async Task PostClient(ClientDto entity) => await _client.ClientPOSTAsync(entity);
    public async Task PostRent(RentDto entity) => await _client.RentPOSTAsync(entity);

    public async Task<Bike> GetBike(int id) => await _client.BikeGETAsync(id);
    public async Task<BikeType> GetBikeType(int id) => await _client.BikeTypeGETAsync(id);
    public async Task<Client> GetClient(int id) => await _client.ClientGETAsync(id);
    public async Task<Rent> GetRent(int id) => await _client.RentGETAsync(id);

    public async Task PutBike(int id, BikeDto entity) => await _client.BikePUTAsync(id, entity);
    public async Task PutBikeType(int id, BikeTypeDto entity) => await _client.BikeTypePUTAsync(id, entity);
    public async Task PutClient(int id, ClientDto entity) => await _client.ClientPUTAsync(id, entity);
    public async Task PutRent(int id, RentDto entity) => await _client.RentPUTAsync(id, entity);

    public async Task DeleteBike(int id) => await _client.BikeDELETEAsync(id);
    public async Task DeleteBikeType(int id) => await _client.BikeTypeDELETEAsync(id);
    public async Task DeleteClient(int id) => await _client.ClientDELETEAsync(id);
    public async Task DeleteRent(int id) => await _client.RentDELETEAsync(id);
}
