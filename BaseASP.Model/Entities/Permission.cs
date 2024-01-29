using BaseASP.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseASP.Model.Entities
{
    public class Permission: EntityBase
    {
        [Required]
        public string Name { get; set; } // CREATE_USER, DELETE_USER: example

        public List<Role> Roles { get; set; }   
    }
}
