using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    class CalendarTaskRepository : Repository<CalendarTask, ApplicationContext>, IRepository<CalendarTask>
    {
        public CalendarTaskRepository(ApplicationContext context) : base(context)
        {

        }
    }

}
