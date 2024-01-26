using BaseASP.Model.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaseASP.Service.JwtService
{
    public class JwtService : IJwtService
    {
        private IConfiguration _config;
        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public User DecodeToken()
        {
            throw new NotImplementedException();
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Id", user.Id.ToString())

            };
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(double.Parse(_config["Jwt:ExpiresDate"])),
                SigningCredentials = credentials
            };

            var jwt = new JwtSecurityTokenHandler();
            var token = jwt.CreateToken(tokenDescriptor);
            return jwt.WriteToken(token);
        }
    }
}
