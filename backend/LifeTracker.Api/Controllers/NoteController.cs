using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LifeTracker.Api.Controllers
{
    [Route("api/note")]
    [ApiController]
    public class NoteController : Controller<Note>
    {
        public NoteController(IService<Note> service) : base(service)
        {

        }
    }
}
