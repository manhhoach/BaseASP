using BaseASP.Model.Entities;

namespace BaseASP.Service.ProductService.Dto
{
    public class ProductDto : Product
    {
        public long TotalRevenue { get; set; }
        public List<Inventory> Inventories { get; set; }
    }
}
