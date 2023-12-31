using System.ComponentModel.DataAnnotations;

namespace BaseASP.API.AuthController.AuthVM
{
    public class SignUpDto
    {
        [Required]
        public string Name { get; set; }
        [MinLength(6)]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
