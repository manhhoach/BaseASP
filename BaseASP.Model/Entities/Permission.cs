using BaseASP.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseASP.Model.Entities
{
    [Table("Permissions")]
    public class Permission : EntityBase
    {
        public string? Name { get; set; } // CREATE_USER, DELETE_USER: example
    }
}
