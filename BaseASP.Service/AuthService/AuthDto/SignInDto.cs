using System.ComponentModel.DataAnnotations;

namespace BaseASP.Service.AuthService.AuthDto
{
    public class SignInDto
    {
        [MinLength(6)]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
