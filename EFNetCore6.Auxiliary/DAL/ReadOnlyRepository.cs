using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace EFNetCore6.Auxiliary.DAL
{
    /// <summary>
    /// Generic repository provide all base needed methods (CRUD)
    /// </summary>
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T>
        where T : class
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly DbContext _context;
        /// <summary>
        /// Ctor with DI
        /// </summary>
        public ReadOnlyRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Get count of all items
        /// </summary>
        public int GetAllCount()
        {
            int result = _dbSet.Count();
            return result;
        }

        /// <summary>
        /// Get first entity by predicate 
        /// </summary>
        /// <param name="predicate">LINQ predicate</param>
        /// <returns>T entity</returns>     
        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.First(predicate);
        }

        /// <summary>
        /// Get first entity by predicate 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>T entity</returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Get first entity
        /// </summary>
        /// <returns>T entity</returns>
        public virtual T FirstOrDefault()
        {
            return _dbSet.FirstOrDefault();
        }

        /// <summary>
        /// Get all queries
        /// </summary>
        /// <returns>IQueryable queries</returns>
        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        /// <summary>
        /// Find queries by predicate (where logic)
        /// </summary>
        /// <param name="predicate">Search predicate (LINQ)</param>
        /// <returns>IQueryable queries</returns>
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        /// <summary>
        /// Find entity by keys
        /// </summary>
        /// <param name="keys">Search key</param>
        /// <returns>T entity</returns>
        public virtual T Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        /// <summary>
        /// Get first entity async
        /// </summary>
        /// <returns>T entity</returns>
        public virtual Task<T> FirstOrDefaultAsync()
        {
            return _dbSet.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Order by
        /// </summary>
        public virtual IOrderedQueryable<T> OrderBy<K>(Expression<Func<T, K>> predicate)
        {
            return _dbSet.OrderBy(predicate);
        }

        /// <summary>
        /// Order by
        /// </summary>
        public virtual IQueryable<IGrouping<K, T>> GroupBy<K>(Expression<Func<T, K>> predicate)
        {
            return _dbSet.GroupBy(predicate);
        }
    }
}
