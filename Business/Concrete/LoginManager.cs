using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dtos;

namespace Business.Concrete
{
    public class LoginManager : ILoginService
    {
        private readonly ILoginDal _loginDal;

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }
        public async Task<UserDto> Authenticate(string username, string password)
        {
            var userInfo =  await _loginDal.Authenticate(username, password);

            if (userInfo == null)
            {
                return new UserDto
                {
                    LoginResult = false
                };
            }    

            return new UserDto
            {
                Password = userInfo.Password,
                Username = userInfo.Username,
                LoginResult = true,
            };
        }
    }
}
