using BaseASP.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseASP.Model.Entities
{
    [Table("RolePermissions")]
    public class RolePermission : EntityBase
    {
        public int RoleId { get; set; }

        public int PermissionId { get; set; }
    }
}
