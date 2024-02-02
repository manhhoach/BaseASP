using BaseASP.Model.Entities;
using System.Security.Claims;

namespace BaseASP.Service.JwtService
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        ClaimsPrincipal DecodeToken(string token);
    }
}
