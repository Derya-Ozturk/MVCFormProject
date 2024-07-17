using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface ILoginDal
    {
        Task<User> Authenticate(string mail, string password);
    }
}
