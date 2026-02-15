using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// Interface that describes interactions with primary key business models
    /// </summary>
    /// <typeparam name="TModel">The type of business model this service will be responsible for.</typeparam>
    public interface IPrimaryService<TModel> : IService<TModel> where TModel : class, IBusinessModel
    {
        void Delete(int id);
        TModel Get(int id);
    }
}
