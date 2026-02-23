using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public class ApplicationUnitOfWork : UnitOfWork<ApplicationContext>, IUnitOfWork<ApplicationContext>
    {
        public ApplicationUnitOfWork(ApplicationContext context,
                IRepository<Note> noteRepo,
                IRepository<Group> groupRepo,
                IRepository<Transaction> transactionRepo,
                IRepository<RecurringTransaction> recurringTransactionRepo,
                IRepository<CalendarTask> calendarTaskRepo,
                IRepository<User> userRepo
                ) : base(context)
        {
            RegisterRepository<Note, IRepository<Note>>(noteRepo);
            RegisterRepository<Group, IRepository<Group>>(groupRepo);

            RegisterRepository<Transaction, IRepository<Transaction>>(transactionRepo);
            RegisterRepository<RecurringTransaction, IRepository<RecurringTransaction>>(recurringTransactionRepo);

            RegisterRepository<CalendarTask, IRepository<CalendarTask>>(calendarTaskRepo);

            RegisterRepository<User, IRepository<User>>(userRepo);
        }

    }
}
