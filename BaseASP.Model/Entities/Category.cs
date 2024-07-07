using BaseASP.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseASP.Model.Entities
{
    [Table("Categories")]
    public class Category : EntityBase
    {
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
