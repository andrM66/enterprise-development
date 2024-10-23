namespace BikeRent.Domain.Repositories;
internal interface BikeTypeRepository
{
    public IEnumerable<BikeType> GetBikeTypes();
    public BikeType? GetBikeType(int id);
    public void PostBikeType(BikeType bikeType);
    public bool PutBikeType(int id, BikeType bikeType);
    public bool DeleteBikeType(int id);
}
