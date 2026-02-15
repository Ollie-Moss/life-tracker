using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DataAccessLayer
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        public Type ModelType { get; set; }
        TEntity Add(TEntity instance);
        TEntity Delete(TEntity instance);
        IList<TEntity> List();
        void Update(TEntity instance);
    }

}