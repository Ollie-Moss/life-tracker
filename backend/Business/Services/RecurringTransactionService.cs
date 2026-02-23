using AutoMapper;
using DataAccessLayer;
using Models;

namespace BusinessLayer.Services
{
    public class RecurringTransactionService : Service<DataAccessLayer.Models.RecurringTransaction, RecurringTransaction>, IService<RecurringTransaction>
    {
        public RecurringTransactionService(IUnitOfWork<ApplicationContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

    }
}
