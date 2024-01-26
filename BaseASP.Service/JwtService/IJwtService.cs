using BaseASP.Model.Entities;

namespace BaseASP.Service.JwtService
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        User DecodeToken();
    }
}
