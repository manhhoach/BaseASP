using BaseASP.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseASP.Model.Entities
{
    public class RolePermission: EntityBase
    {     
        public int RoleId { get; set; }

        public int PermissionId { get; set; }
    }
}
