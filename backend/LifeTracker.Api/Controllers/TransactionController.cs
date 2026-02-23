using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LifeTracker.Api.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : Controller<Transaction>
    {
        public TransactionController(IService<Transaction> service) : base(service)
        {

        }
    }
}
