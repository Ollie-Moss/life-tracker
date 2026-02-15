using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    /// <summary>
    /// Extends <see cref="UnitOfWorkBase{TDbContext}"/> to implement accomodate for various repository types.
    /// </summary>
    /// <typeparam name="TDbContext">DBContext for EF to use for DB mapping.</typeparam>
    public class UnitOfWork<TDbContext> : UnitOfWorkBase<TDbContext>, IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        protected readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(TDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Returns the repository associated with the database model.
        /// </summary>
        /// <typeparam name="TEntity">The database model associated with the repository</typeparam>
        /// <param name="context">The context.</param>
        public IPrimaryRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IDatabaseModel
        {
            if (!_repositories.TryGetValue(typeof(TEntity), out var repo))
            {
                throw new InvalidOperationException($"No repository registered for type {typeof(TEntity).Name}");
            }
            return (Repository<TEntity, TDbContext>)repo;
        }

        /// <summary>
        /// Returns the repository associated with the database model.
        /// </summary>
        /// <typeparam name="TEntity">The database model associated with the repository</typeparam>
        /// <param name="context">The context.</param>
        public ICompositeRepository<TEntity> GetCompositeRepository<TEntity>() where TEntity : class, IDatabaseModelComposite
        {
            if (!_repositories.TryGetValue(typeof(TEntity), out var repo))
            {
                throw new InvalidOperationException($"No repository registered for type {typeof(TEntity).Name}");
            }
            return (CompositeRepository<TEntity, TDbContext>)repo;
        }
    }
}
