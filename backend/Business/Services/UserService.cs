using AutoMapper;
using DataAccessLayer;
using Models;

namespace BusinessLayer.Services
{
    public class UserService : Service<DataAccessLayer.Models.User, User>, IService<User>
    {
        public UserService(IUnitOfWork<ApplicationContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

    }
}
