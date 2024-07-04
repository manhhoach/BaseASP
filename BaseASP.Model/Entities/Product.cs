using BaseASP.Model.Common;

namespace BaseASP.Model.Entities
{
    public class Product : EntityBase
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
