using BaseASP.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseASP.Model.Entities
{
    [Table("Users")]
    public class User : EntityBase
    {
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string? Name { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

        public int RoleId { get; set; }

    }
}
