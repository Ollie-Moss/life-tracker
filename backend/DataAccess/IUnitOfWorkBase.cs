using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{

    public interface IUnitOfWorkBase
    {
        void Dispose();
        void Save();
    }
}