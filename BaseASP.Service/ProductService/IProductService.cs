using BaseASP.Model.Entities;
using BaseASP.Service.Common;
using BaseASP.Service.ProductService.Dto;

namespace BaseASP.Service.ProductService
{
    public interface IProductService : IEntityBaseService<Product>
    {
        List<ProductDto> TotalRevenue();
    }
}
