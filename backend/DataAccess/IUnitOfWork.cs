using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IUnitOfWorkBase
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IDataModel;

        void RegisterRepository<TEntity, TRepository>(TRepository repository)
            where TEntity : class, IDataModel
            where TRepository : class, IRepository<TEntity>;
    }

    public interface IUnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
    }
}
