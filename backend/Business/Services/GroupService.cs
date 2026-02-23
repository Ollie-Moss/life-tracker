using AutoMapper;
using DataAccessLayer;
using Models;

namespace BusinessLayer.Services
{
    public class GroupService : Service<DataAccessLayer.Models.Group, Group>, IService<Group>
    {
        public GroupService(IUnitOfWork<ApplicationContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

    }
}
