using DataAccessLayer;
using DataAccessLayer.Models;
using Models;

namespace BusinessLayer
{
    /// <summary>
    /// Describes all basic CRUD operations for a given database object and business model.<br></br>
    /// Uses <see cref="IUnitOfWork{TDbContext}"/> and <see cref="IPrimaryRepository{TEntity}"/> to interact with the database.
    /// </summary>
    /// <typeparam name="TDatabaseModel">The database model to be mapped between.</typeparam>
    /// <typeparam name="TBusinessModel">The business model to be mapped between.</typeparam>
    public class Service<TDatabaseModel, TBusinessModel> : ServiceBase, IPrimaryService<TBusinessModel> 
        where TDatabaseModel : class, IDatabaseModel
        where TBusinessModel : class, IBusinessModel
    {
        public Service(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        /// <summary>
		/// Retrieves a business model by its ID.
		/// </summary>
		/// <param name="id">The ID of the model to retrieve.</param>
		/// <returns>The business model or <c>null</c> if not found.</returns>
        public virtual TBusinessModel Get(int id)
        {
            var data = UnitOfWork.GetRepository<TDatabaseModel>().Get(id);
            if (data == null) return null;

            var model = Activator.CreateInstance<TBusinessModel>();

            Mapper.Map(data, model);

            return model;
        }

        /// <summary>
		/// Adds a business model to the database.
		/// </summary>
		/// <param name="model">The business model to add.</param>
		/// <returns>The ID of the newly added entity.</returns>
        public virtual int Add(TBusinessModel model)
        {
            Validate(model);

            var data = Activator.CreateInstance<TDatabaseModel>();

            Mapper.Map(model, data);

            UnitOfWork.GetRepository<TDatabaseModel>().Add(data);
            UnitOfWork.Save();

            return data.Id;
        }


        /// <summary>
		/// Updates an existing business model in the database.
		/// </summary>
		/// <param name="model">The new values.</param>
		/// <returns>The ID of the entity.</returns>
        public virtual int Update(TBusinessModel model)
        {
            Validate(model);

            var data = UnitOfWork.GetRepository<TDatabaseModel>().Get(model.Id);

            Mapper.Map(model, data);

            UnitOfWork.GetRepository<TDatabaseModel>().Update(data);
            UnitOfWork.Save();

            return data.Id;
        }

        /// <summary>
		/// Deletes an entity from the database by ID.
		/// </summary>
		/// <param name="id">The ID of the entity to delete.</param>
        public virtual void Delete(int id)
        {
            UnitOfWork.GetRepository<TDatabaseModel>().Delete(id);
            UnitOfWork.Save();
        }

        /// <summary>
		/// Retrieves all business models from the database.
		/// </summary>
		/// <returns>A list of all business models.</returns>
        public virtual IList<TBusinessModel> List()
        {
            var artists = UnitOfWork.GetRepository<TDatabaseModel>().List();

            var models = new List<TBusinessModel>();

            Mapper.Map(artists, models);

            return models;
        }
    }
}

