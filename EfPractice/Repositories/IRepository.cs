namespace EfPractice.Repositories;

public interface IRepository<T>
{
    void Create(T entity);
    IEnumerable<T> GetAll();
    T? GetById(int id);
    void Update(T entity);
    void Delete(int id);
}