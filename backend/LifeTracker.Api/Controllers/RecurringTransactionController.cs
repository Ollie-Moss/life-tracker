using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LifeTracker.Api.Controllers
{
    [Route("api/recurring-transaction")]
    [ApiController]
    public class RecurringTransactionController : Controller<RecurringTransaction>
    {
        public RecurringTransactionController(IService<RecurringTransaction> service) : base(service)
        {

        }
    }
}
