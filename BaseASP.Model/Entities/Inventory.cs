using BaseASP.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseASP.Model.Entities
{
    [Table("Inventories")]
    public class Inventory : EntityBase
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? TransactionType { get; set; } // 'IN' or 'OUT'
        public DateTime TransactionDate { get; set; }
    }
}
