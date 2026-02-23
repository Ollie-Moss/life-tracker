using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace LifeTracker.Api.Controllers
{
    /// <summary>
    /// Generic base controller for managing CRUD operations on business models.
    /// </summary>
    /// <typeparam name="TModel">The type of the business model this controller is responsible for.</typeparam>
    public class Controller<TModel> : ControllerBase
        where TModel : class, IModel
    {
        /// <summary>
		/// The service responsible for handling operations on the business model.
		/// </summary>
        protected IService<TModel> _service;

        public Controller(IService<TModel> service)
        {
            _service = service;
        }

        /// <summary>
		/// The service responsible for handling operations on the business model.
		/// </summary>
        [HttpGet]
        public virtual async Task<IList<TModel>> Get()
        {
            return await Task.Run(_service.List);
        }

        /// <summary>
		/// Retrieves a model by its ID.
		/// </summary>
		/// <param name="id">The ID of the model.</param>
		/// <returns>The <typeparamref name="TModel"/>.</returns>
        [HttpGet("{id}")]
        public virtual async Task<TModel> Get(Guid id)
        {
            return await Task.Run(() => _service.Get(id));

        }

        /// <summary>
		/// Adds a new model to the database.
		/// </summary>
		/// <param name="model">The model to add.</param>
		/// <returns>The ID of the created model.</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TModel model)
        {
            Guid Id = await Task.Run(() => _service.Add(model));
            return Ok(Id);
        }

        /// <summary>
		/// Updates an existing model.
		/// </summary>
		/// <param name="model">The model with updated data.</param>
		/// <returns>The ID of the updated model.</returns>
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TModel model)
        {
            Guid Id = await Task.Run(() => _service.Update(model));
            return Ok(Id);
        }

        /// <summary>
		/// Deletes a model by its ID.
		/// </summary>
		/// <param name="id">The ID of the model to delete.</param>
		/// <returns>The ID of the delted model.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
