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
    public interface IService<TModel> : IServiceBase<TModel> where TModel : class, IModel
    {
        void Delete(Guid id);
        TModel Get(Guid id);
    }
}
