using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class, IDataModel
    {
        TEntity Delete(Guid id);
        TEntity Get(Guid id);
    }
}
