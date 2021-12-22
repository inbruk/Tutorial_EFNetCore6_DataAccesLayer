using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace EFNetCore6.Auxiliary.DAL
{
    /// <summary>
    /// Generic repository provide all base needed methods (CRUD)
    /// </summary>
    public interface IReadOnlyRepository<T>
        where T : class
    {
        /// <summary>
        /// Get count of all items
        /// </summary>
        int GetAllCount();

        /// <summary>
        /// Get first entity by predicate 
        /// </summary>
        /// <param name="predicate">LINQ predicate</param>
        /// <returns>T entity</returns>
        T First(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get first entity by predicate 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>T entity</returns>
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get first entity
        /// </summary>
        /// <returns>T entity</returns>
        T FirstOrDefault();

        /// <summary>
        /// Get first entity async
        /// </summary>
        /// <returns>T entity</returns>
        Task<T> FirstOrDefaultAsync();

        /// <summary>
        /// Get all queries
        /// </summary>
        /// <returns>IQueryable queries</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Find queries by predicate (where logic)
        /// </summary>
        /// <param name="predicate">Search predicate (LINQ)</param>
        /// <returns>IQueryable queries</returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find queries by predicate
        /// </summary>
        /// <param name="predicate">Search predicate (LINQ)</param>
        /// <returns>IQueryable queries</returns>
        bool Any(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find entity by keys
        /// </summary>
        /// <param name="keys">Search key</param>
        /// <returns>T entity</returns>
        T Find(params object[] keys);

        /// <summary>
        /// Order by
        /// </summary>
        IOrderedQueryable<T> OrderBy<K>(Expression<Func<T, K>> predicate);

        /// <summary>
        /// Order by
        /// </summary>
        IQueryable<IGrouping<K, T>> GroupBy<K>(Expression<Func<T, K>> predicate);
    }
}
