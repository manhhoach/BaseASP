using BaseASP.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseASP.Model.Entities
{
    [Table("Products")]
    public class Product : EntityBase
    {
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
