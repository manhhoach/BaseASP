using BaseASP.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseASP.Model.Entities
{
    [Table("Roles")]
    public class Role : EntityBase
    {
        public string? Name { get; set; }
    }
}
