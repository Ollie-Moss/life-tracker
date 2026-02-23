using AutoMapper;
using DataAccessLayer;
using Models;

namespace BusinessLayer.Services
{
    public class TransactionService : Service<DataAccessLayer.Models.Transaction, Transaction>, IService<Transaction>
    {
        public TransactionService(IUnitOfWork<ApplicationContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

    }
}
