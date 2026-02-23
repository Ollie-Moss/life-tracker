
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    class NoteRepository : Repository<Note, ApplicationContext>, IRepository<Note>
    {
        public NoteRepository(ApplicationContext context) : base(context)
        {

        }

    }

}

