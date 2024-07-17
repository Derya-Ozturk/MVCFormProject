using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, new()
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter);
    }
}
