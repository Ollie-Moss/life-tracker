
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    class RecurringTransactionRepository : Repository<RecurringTransaction, ApplicationContext>, IRepository<RecurringTransaction>
    {
        public RecurringTransactionRepository(ApplicationContext context) : base(context)
        {

        }

    }

}
