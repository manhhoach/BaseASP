using BaseASP.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseASP.Model.Entities
{
    public class Role: EntityBase
    {
        [Required]
        public string Name { get; set; }

        public List<Permission> Permissions { get; set; }
    }
}
