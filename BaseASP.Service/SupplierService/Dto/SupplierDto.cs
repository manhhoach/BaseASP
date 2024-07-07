using BaseASP.Model.Entities;

namespace BaseASP.Service.SupplierService.Dto
{
    public class SupplierDto : Supplier
    {
        public long TotalInventory { get; set; }
    }
}
