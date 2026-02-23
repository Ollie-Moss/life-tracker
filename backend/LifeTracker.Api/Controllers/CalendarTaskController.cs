using BusinessLayer;
using BusinessLayer.Services;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LifeTracker.Api.Controllers
{
    [Route("api/calendar-task")]
    [ApiController]
    public class CalendarTaskController : Controller<CalendarTask>
    {
        public CalendarTaskController(IService<CalendarTask> service) : base(service)
        {

        }

        // Disable Default Get()
        [NonAction]
        public override Task<IList<CalendarTask>> Get()
        {
            return base.Get();
        }

        // [HttpGet]
        // public async Task<IList<CalendarTask>> Get([FromQuery] int? upcomingDays, [FromQuery] DateOnly? date)
        // {
        //     var service = (CalendarTaskService)_service;
        //     IList<CalendarTask> results = _service.List();
        //
        //     if (upcomingDays != null)
        //     {
        //         results = results.Where(task =>
        //                 DateOnly.FromDateTime(task.Date) >= DateOnly.FromDateTime(DateTime.Now) &&
        //                 DateOnly.FromDateTime(task.Date) < DateOnly.FromDateTime(DateTime.Now.AddDays((double)upcomingDays)
        //                     ))
        //             .ToList();
        //     }
        //
        //     if (date != null)
        //         results = results.Where(task => DateOnly.FromDateTime(task.Date) == date).ToList();
        //
        //     return await Task.Run(() => results);
        // }

        [HttpGet]
        public async Task<IList<CalendarTask>> Get([FromQuery] int? upcomingDays, [FromQuery] DateOnly? date)
        {
            var service = (CalendarTaskService)_service;
            QueryBuilder<CalendarTask> queryBuilder = new();

            IList<CalendarTask> results = _service.List();

            if (upcomingDays != null)
                queryBuilder.Add(task =>
                        DateOnly.FromDateTime(task.Date) >= DateOnly.FromDateTime(DateTime.Now) &&
                        DateOnly.FromDateTime(task.Date) < DateOnly.FromDateTime(DateTime.Now.AddDays((double)upcomingDays)));

            if (date != null)
                queryBuilder.Add(task => DateOnly.FromDateTime(task.Date) == date);

            return await Task.Run(() => _service.Get(queryBuilder));
        }
    }
}
