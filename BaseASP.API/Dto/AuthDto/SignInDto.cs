using System.ComponentModel.DataAnnotations;

namespace BaseASP.API.Dto.AuthDto
{
    public class SignInDto
    {
        [MinLength(6)]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
