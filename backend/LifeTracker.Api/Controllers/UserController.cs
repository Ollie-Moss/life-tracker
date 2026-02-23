using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LifeTracker.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller<User>
    {
        public UserController(IService<User> service) : base(service)
        {

        }
    }
}
