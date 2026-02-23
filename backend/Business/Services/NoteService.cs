using AutoMapper;
using DataAccessLayer;
using Models;

namespace BusinessLayer.Services
{
    public class NoteService : Service<DataAccessLayer.Models.Note, Note>, IService<Note>
    {
        public NoteService(IUnitOfWork<ApplicationContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

    }
}
