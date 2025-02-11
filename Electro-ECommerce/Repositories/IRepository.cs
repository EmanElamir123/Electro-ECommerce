using System.Linq.Expressions;

namespace Electro_ECommerce.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
