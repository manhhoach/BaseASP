using BaseASP.Model.Entities;
using BaseASP.Repository.Common;
using BaseASP.Repository.InventoryRepository;
using BaseASP.Repository.ProductRepository;
using BaseASP.Service.Common;
using BaseASP.Service.ProductService.Dto;

namespace BaseASP.Service.ProductService
{
    public class ProductService : EntityBaseService<Product>, IProductService
    {
        IProductRepository _productRepository;
        IInventoryRepository _inventoryRepository;

        public ProductService(
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            IInventoryRepository inventoryRepository
            ) :
            base(unitOfWork, productRepository)
        {
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
        }

        //Câu hỏi 1: Tổng doanh thu của sản phẩm
        //Hãy viết truy vấn LINQ để tính tổng nhập xuất của sản phẩm
        public List<ProductDto> TotalRevenue()
        {
            var query = from p in _productRepository.GetAllAsQueryable()

                        join i in _inventoryRepository.GetAllAsQueryable()
                        on p.Id equals i.ProductId
                        into inventoryTable
                        from inventory in inventoryTable.DefaultIfEmpty()

                        group inventory by new { p.Id, p.ProductName } into g
                        orderby g.Key.Id ascending
                        select new ProductDto
                        {
                            Id = g.Key.Id,
                            ProductName = g.Key.ProductName,
                            TotalRevenue = (g.Where(x => x.TransactionType == "IN").Sum(x => x.Quantity) - g.Where(x => x.TransactionType == "OUT").Sum(x => x.Quantity))
                        };
            return query.Take(100).ToList();
        }
    }
}
