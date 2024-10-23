namespace BikeRent.Domain.Repositories;
internal interface BikeRepoitory
{
    public IEnumerable<Bike> GetBikes();
    public Bike? GetBike(int id);
    public void PostBike(Bike bike);
    public bool PutBike(int id, Bike bike);
    public bool DeleteBike(int id);
}