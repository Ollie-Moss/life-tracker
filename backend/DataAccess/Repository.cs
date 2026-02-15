using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    /// <summary>
    /// Generic repository for basic CRUD operations on entities.
    /// </summary>
    /// <typeparam name="TEntity">The entity type this repository will be responsible for.F</typeparam>
    /// <typeparam name="TDbContext">DBContext for EF to use for DB mapping.</typeparam>
    public class Repository<TEntity, TDbContext> : IPrimaryRepository<TEntity> 
        where TEntity : class, IDatabaseModel
        where TDbContext : DbContext
    {

        public Repository(TDbContext context)
        {
            Context = context;
        }

        public Type ModelType { get; set; } = typeof(TEntity);
        public TDbContext Context { get; private set; }


        /// <summary>
        /// Creates a <see cref="DbSet<T>" /> that can be used to query and save instances of <see cref="DbSet<T>" />.
        /// </summary>
        protected virtual IQueryable<TEntity> All
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }

        /// <summary>
        /// Adds an entity to the context and sets the entiy state to  <see cref="EntityState.Added" />.
        /// Entities with the added stste will be inserted in the database when SaveChanges() is called.
        /// </summary>
        /// <param name="instance"></param>
        public virtual TEntity Add(TEntity instance)
        {
            if (instance != null)
            {
                var entity = Context.Set<TEntity>().Add(instance);
                return entity.Entity;
            }
            return instance;
        }

        /// <summary>
        /// Gets an entity
        /// </summary>
        /// <param name="id">The entity ID</param>
        /// <returns></returns>
        public virtual TEntity Get(int id)
        {
            return All.FirstOrDefault(a => a.Id == id);
        }
        public virtual TEntity Delete(int id)
        {
            return Delete(Get(id));
        }

        /// <summary>
        /// Changes the entiy state to  <see cref="EntityState.Deleted" />.
        /// Entities with the deleted state will be update in the database when Save() is called.
        /// </summary>
        /// <param name="instance"></param>
        public virtual TEntity Delete(TEntity instance)
        {
            if (instance != null)
            {
                Context.Entry(instance).State = EntityState.Deleted;
            }
            return instance;
        }

        /// <summary>
        /// Changes the entiy state to  <see cref="EntityState.Modified" />.
        /// Entities with the modified stste will be updated in the database when Save() is called.
        /// </summary>
        /// <param name="instance"></param>

        public virtual void Update(TEntity instance)
        {
            if (instance != null)
            {
                Context.Entry(instance).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Lists the entities
        /// </summary>
        /// <returns></returns>
        public virtual IList<TEntity> List()
        {
            return All.ToList();
        }
    }
}
