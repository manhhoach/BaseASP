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

        private string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public async Task SignUp(User dto)
        {
            var user = await _userService.FindOne(u=>u.Email == dto.Email);
            if(user == null)
            {
                await _userService.Add(dto);
            }
            else
            {
                throw new HttpRequestException("Email already exists", null, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
