using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public interface IPrimaryRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, IDatabaseModel
    {
        TEntity Delete(int id);
        TEntity Get(int id);
    }
}
