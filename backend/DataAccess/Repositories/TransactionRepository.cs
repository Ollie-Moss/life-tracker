using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    class TransactionRepository : Repository<Transaction, ApplicationContext>, IRepository<Transaction>
    {
        public TransactionRepository(ApplicationContext context) : base(context)
        {

        }

    }

}
