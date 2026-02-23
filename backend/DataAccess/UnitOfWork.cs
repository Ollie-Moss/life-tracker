using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
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
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IDataModel
        {
            if (!_repositories.TryGetValue(typeof(TEntity), out var repo))
            {
                throw new InvalidOperationException($"No repository registered for type {typeof(TEntity).Name}");
            }
            return (Repository<TEntity, TDbContext>)repo;
        }

        /// <summary>
        /// Maps a given <typeparamref name="TEntity"/> to a <typeparamref name="TRepository"/>.
        /// </summary>
        /// <typeparam name="TEntity">The database model associated with the repository</typeparam>
        /// <typeparam name="TRepository">The repository containing the Entity</typeparam>
        /// <param name="repository">The repository.</param>
        public void RegisterRepository<TEntity, TRepository>(TRepository repository)
            where TEntity : class, IDataModel
            where TRepository : class, IRepository<TEntity>
        {
            _repositories.Add(typeof(TEntity), repository);
        }
    }
}
