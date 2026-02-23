using AutoMapper;
using DataAccessLayer;
using Models;

namespace BusinessLayer.Services
{
    public class CalendarTaskService : Service<DataAccessLayer.Models.CalendarTask, CalendarTask>, IService<CalendarTask>
    {
        public CalendarTaskService(IUnitOfWork<ApplicationContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public List<CalendarTask> GetUpcomingTasks(int upcomingDays)
        {

            var rangeStart = DateTime.Now;
            var rangeEnd = DateTime.Now.AddDays(upcomingDays);

            return List().Where(task => task.Date >= rangeStart && task.Date < rangeEnd).ToList();
        }

        public List<CalendarTask> GetCalendarTasksByDay(DateOnly date)
        {
            return List().Where(task => DateOnly.FromDateTime(task.Date) == date).ToList();
        }

    }
}
