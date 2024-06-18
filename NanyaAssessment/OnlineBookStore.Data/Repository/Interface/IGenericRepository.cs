using System.Linq.Expressions;

namespace OnlineBookStore.Data.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string includeProperties = null);
        Task<IEnumerable<T>> GetAllAsync(string includeProperties = null);
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> filter);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
