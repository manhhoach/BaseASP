using BaseASP.Model.Entities;
using BaseASP.Service.JwtService;
using BaseASP.Service.UserService;
using System.Net;

namespace BaseASP.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        public AuthService(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }
        public async Task<string> SignIn(User dto)
        {
            User user = await _userService.FindOne(u => u.Email == dto.Email);
            if(user == null)
            {
                throw new HttpRequestException("Email is not exists", null, HttpStatusCode.NotFound);
            }
            else
            {
                bool isCorrectPassword = ComparePassword(dto.Password, user.Password);
                if(isCorrectPassword)
                {
                    // gen token here
                    string token = _jwtService.GenerateToken(user);
                    return token;
                }
                else
                {
                    throw new HttpRequestException("Password is invalid", null, HttpStatusCode.BadRequest);
                }
            }

        }

        private bool ComparePassword(string password, string hashPassword)
        {    
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
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
                throw new HttpRequestException("Email already exists", null, HttpStatusCode.BadRequest);
            }
        }
    }
}
