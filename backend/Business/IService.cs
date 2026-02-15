using Models;

namespace BusinessLayer
{
    /// <summary>
    /// Interface for all service operations decoupled from unique identifier style.<br></br>
    /// </summary>
    /// <typeparam name="TModel">The type of business model this service will be responsible for.</typeparam>
    public interface IService<TModel> where TModel : class
    {
        int Add(TModel model);
        IList<TModel> List();
        int Update(TModel model);
    }
}