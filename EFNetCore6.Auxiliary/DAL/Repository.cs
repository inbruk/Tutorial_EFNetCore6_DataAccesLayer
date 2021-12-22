using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace EFNetCore6.Auxiliary.DAL
{
    /// <summary>
    /// Generic repository provide all base needed methods (CRUD)
    /// </summary>
    public class Repository<T> : ReadOnlyRepository<T>, IRepository<T>
        where T : class
    {
        /// <summary>
        /// Ctor with DI
        /// </summary>
        public Repository(DbContext context)
            : base(context)            
        {
        }

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Add new entitities
        /// </summary>
        /// <param name="entities">Entity collection</param>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        /// <summary>
        /// Remove entity from database
        /// </summary>
        /// <param name="entity">Entity object</param>
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Remove entities from database
        /// </summary>
        /// <param name="entity">Entity object</param>
        public virtual void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Update entities
        /// </summary>
        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            foreach(var item in entities)
                _context.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Persists all updates to the data source
        /// </summary>
        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Persists all updates to the data source async
        /// </summary>
        public virtual Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove range of given entities
        /// </summary>
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
