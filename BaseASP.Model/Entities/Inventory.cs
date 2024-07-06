using BaseASP.Model.Common;

namespace BaseASP.Model.Entities
{
    public class Inventory : EntityBase
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } // 'IN' or 'OUT'
        public DateTime TransactionDate { get; set; }
    }
}
