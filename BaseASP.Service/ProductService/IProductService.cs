using BaseASP.Model.Entities;
using BaseASP.Service.Common;
using BaseASP.Service.ProductService.Dto;
using BaseASP.Service.SupplierService.Dto;

namespace BaseASP.Service.ProductService
{
    public interface IProductService : IEntityBaseService<Product>
    {
        List<ProductDto> CalculateTotalTransactions();
        List<ProductDto> GetProductsWithoutTransaction();
        List<SupplierDto> GetSupplierWithLargestInventory();
    }
}
