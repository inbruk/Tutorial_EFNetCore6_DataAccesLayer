using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace EFNetCore6.Auxiliary.DAL
{
    /// <summary>
    /// Generic repository provide all base needed methods (CRUD)
    /// </summary>
    public interface IRepository<T> : IReadOnlyRepository<T>
        where T : class
    {
        /// <summary>
        /// Persists all updates to the data source
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Persists all updates to the data source async
        /// </summary>
        Task SaveChangesAsync();

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        void Add(T entity);

        /// <summary>
        /// Add new entities
        /// </summary>
        /// <param name="entities">Entity collection</param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Remove entity from database
        /// </summary>
        /// <param name="entity">Entity object</param>
        void Delete(T entity);

        /// <summary>
        /// Remove entities from database
        /// </summary>
        void DeleteRange(IEnumerable<T> entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        void Update(T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Remove range of given entities
        /// </summary>
        void RemoveRange(IEnumerable<T> entities);
    }
}
