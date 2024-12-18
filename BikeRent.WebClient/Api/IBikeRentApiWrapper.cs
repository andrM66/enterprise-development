namespace BikeRent.WebClient.Api;

public interface IBikeRentApiWrapper
{
    Task DeleteBike(int id);
    Task DeleteBikeType(int id);
    Task DeleteClient(int id);
    Task DeleteRent(int id);
    Task<IEnumerable<Bike>> GetAllBikes();
    Task<IEnumerable<BikeType>> GetAllBikeTypes();
    Task<IEnumerable<Client>> GetAllClients();
    Task<IEnumerable<Rent>> GetAllRents();
    Task<Bike> GetBike(int id);
    Task<BikeType> GetBikeType(int id);
    Task<Client> GetClient(int id);
    Task<Rent> GetRent(int id);
    Task PostBike(BikeDto entity);
    Task PostBikeType(BikeTypeDto entity);
    Task PostClient(ClientDto entity);
    Task PostRent(RentDto entity);
    Task PutBike(int id, BikeDto entity);
    Task PutBikeType(int id, BikeTypeDto entity);
    Task PutClient(int id, ClientDto entity);
    Task PutRent(int id, RentDto entity);
    Task<IEnumerable<Bike>> Request1();

    Task<IEnumerable<Client>> Request2();

    Task<IEnumerable<TypeTimeDto>> Request3();

    Task<IEnumerable<Client>> Request4();

    Task<IEnumerable<BikeCountDto>> Request5();

    Task<TimeStatDto> Request6();
}