using BaseASP.Model.Entities;

namespace BaseASP.Service.AuthService
{
    public interface IAuthService
    {
        public Task SignUp(User dto);
        public Task<User> SignIn(User dto);
    }
}
