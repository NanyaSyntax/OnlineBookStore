using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Data.Context;
using OnlineBookStore.Data.Repository.Interface;
using System.Linq.Expressions;

namespace OnlineBookStore.Data.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OnlineBookStoreDbContext _context;
        internal DbSet<T> DbSet;

        public GenericRepository(OnlineBookStoreDbContext context)
        {
            _context = context;
            this.DbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, string includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(string includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> filter)
        {
            return await DbSet.Where(filter).ToListAsync();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }
    }
}
