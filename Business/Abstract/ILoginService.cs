using Entities.Dtos;

namespace Business.Abstract
{
    public interface ILoginService
    {
        Task<UserDto> Authenticate(string username, string password);
    }
}
