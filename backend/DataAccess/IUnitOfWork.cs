using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public interface IUnitOfWork  : IUnitOfWorkBase
    {
        ICompositeRepository<TEntity> GetCompositeRepository<TEntity>() where TEntity : class, IDatabaseModelComposite;
        IPrimaryRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IDatabaseModel;
    }

    public interface IUnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
    }
}