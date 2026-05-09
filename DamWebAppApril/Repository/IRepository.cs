using DamWebAppApril.Models;

namespace DamWebAppApril.Repository
{
    public interface IRepository<T>
    {
        //Common MEthod between repos "CRUD"
        List<T> GetAll();
        T GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        int Save();
    }
}
