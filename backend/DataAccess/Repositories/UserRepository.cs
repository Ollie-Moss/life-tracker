using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    class UserRepository : Repository<User, ApplicationContext>, IRepository<User>
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }

    }

}

