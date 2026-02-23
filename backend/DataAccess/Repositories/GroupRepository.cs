using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    class GroupRepository : Repository<Group, ApplicationContext>, IRepository<Group>
    {
        public GroupRepository(ApplicationContext context) : base(context)
        {
        }

    }

}
