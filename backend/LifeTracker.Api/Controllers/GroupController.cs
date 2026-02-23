using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LifeTracker.Api.Controllers
{
    [Route("api/group")]
    [ApiController]
    public class GroupController : Controller<Group>
    {
        public GroupController(IService<Group> service) : base(service)
        {

        }
    }
}
