namespace BikeRent.Domain.Repositories;

internal interface RentRepository
{
    public IEnumerable<Rent> GetRents();
    public Rent? GetRent(int id);
    public bool DeleteRent(int id);
    public void PostRent(Rent rent);
    public bool PutRent(int id, Rent rent);
}
