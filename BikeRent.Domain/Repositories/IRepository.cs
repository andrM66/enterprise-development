namespace BikeRent.Domain.Repositories;
public interface IRepository<T, Tid>
{
    public IEnumerable<T> GetAll();
    public T? GetById(int id);
    public bool Delete(int id);
    public bool Put(T entity, int id);
    public void Post(T entity);
}
