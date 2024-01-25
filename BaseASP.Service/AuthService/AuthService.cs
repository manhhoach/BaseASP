using BaseASP.Model.Entities;
using BaseASP.Service.UserService;

namespace BaseASP.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        public AuthService(IUserService userService)
        {
            _userService = userService;
        }
        public Task<User> SignIn(User dto)
        {
            throw new NotImplementedException();
        }

        public async Task SignUp(User dto)
        {
            await _userService.Add(dto);
        }
    }
}
