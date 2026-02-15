using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
	/// Provides a base implementation for service classes, including validation and mapping support.
	/// </summary>
    public abstract class ServiceBase
    {
        protected IUnitOfWork UnitOfWork { get; private set; }
        protected IMapper Mapper { get; private set; }

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Mapper = MapperFactory.CreateMapper<MappingProfile>();
        }

        /// <summary>
		/// Validates the model using <see cref="ModelValidator"/>.<br></br>
		/// Throws a <see cref="ModelValidationException"/> if validation fails.
		/// </summary>
		/// <param name="model">The model to validate.</param>
		/// <returns><c>true</c> if the model is valid; otherwise, an exception is thrown.</returns>
		/// <exception cref="ModelValidationException">Thrown when the model is invalid.</exception>
        protected virtual bool Validate(object model)
        {
            var modelValidator = new ModelValidator();
            if (!modelValidator.Validate(model))
            {
                throw new ModelValidationException($"{nameof(model)} is invalid", modelValidator.Errors);
            }
            return true;
        }
    }
}
