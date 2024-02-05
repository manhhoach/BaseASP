using BaseASP.Model.Entities;
using BaseASP.Service.UserService;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaseASP.Service.JwtService
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public ClaimsPrincipal DecodeToken(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            var tokenValidateParams = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:secretKey"]))
            };

            SecurityToken jsonToken;
            var principal =  handler.ValidateToken(token,tokenValidateParams, out jsonToken);
            return principal;       

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
