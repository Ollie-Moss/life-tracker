using DataAccessLayer;

namespace BusinessLayer
{
    /// <summary>
    /// Interface for all service operations decoupled from unique identifier style.<br></br>
    /// </summary>
    /// <typeparam name="TModel">The type of business model this service will be responsible for.</typeparam>
    public interface IServiceBase<TModel> where TModel : class
    {
        Guid Add(TModel model);
        IList<TModel> Get(QueryBuilder<TModel> query);
        IList<TModel> List();
        Guid Update(TModel model);
    }
}
