using BaseASP.Model.Entities;
using BaseASP.Repository.Common;
using BaseASP.Repository.InventoryRepository;
using BaseASP.Repository.ProductRepository;
using BaseASP.Repository.SupplierRepository;
using BaseASP.Service.Common;
using BaseASP.Service.ProductService.Dto;
using BaseASP.Service.SupplierService.Dto;

namespace BaseASP.Service.ProductService
{
    public class ProductService : EntityBaseService<Product>, IProductService
    {
        IProductRepository _productRepository;
        IInventoryRepository _inventoryRepository;
        ISupplierRepository _supplierRepository;

        public ProductService(
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            IInventoryRepository inventoryRepository,
             ISupplierRepository supplierRepository
            ) :
            base(unitOfWork, productRepository)
        {
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
        }

        //Câu hỏi 1: Tổng doanh thu của sản phẩm
        //Hãy viết truy vấn LINQ để tính tổng nhập xuất của sản phẩm
        public List<ProductDto> CalculateTotalTransactions()
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

        public List<ProductDto> GetProductsWithoutTransaction()
        {
            var query = from product in _productRepository.GetAllAsQueryable()

                        join inventory in _inventoryRepository.GetAllAsQueryable()
                        on product.Id equals inventory.ProductId
                        into inventoryTable
                        from i in inventoryTable.DefaultIfEmpty()
                        where i == null || i.ProductId == 0
                        select new ProductDto
                        {
                            Id = product.Id,
                            ProductName = product.ProductName,
                        };
            return query.Take(100).ToList();
        }

        //Câu hỏi 3: Nhà cung cấp có số lượng sản phẩm lớn nhất
        //Viết truy vấn LINQ để lấy nhà cung cấp có tổng số lượng sản phẩm lớn nhất trong kho.
        public List<SupplierDto> GetSupplierWithLargestInventory()
        {
            var query = from supplier in _supplierRepository.GetAllAsQueryable()

                        join product in _productRepository.GetAllAsQueryable()
                        on supplier.Id equals product.SupplierId

                        join inventory in _inventoryRepository.GetAllAsQueryable().Where(x => x.TransactionType == "IN")
                        on product.Id equals inventory.ProductId
                        into inventoryTable
                        from i in inventoryTable.DefaultIfEmpty()
                        group i by new { supplier.Id, supplier.SupplierName } into g

                        select new SupplierDto
                        {
                            Id = g.Key.Id,
                            SupplierName = g.Key.SupplierName,
                            TotalInventory = g.Sum(x => x.Quantity)
                        };
            return query.OrderByDescending(x => x.TotalInventory).Take(100).ToList();
        }

        //Câu hỏi 4: Sản phẩm có giao dịch gần đây nhất
        //Viết truy vấn LINQ để lấy sản phẩm có giao dịch kho hàng gần đây nhất.

        //Câu hỏi 5: Danh mục và số lượng sản phẩm trung bình
        //Viết truy vấn LINQ để lấy danh mục và số lượng sản phẩm trung bình của từng danh mục.

        //Câu hỏi 6: Sản phẩm có nhiều giao dịch 'OUT' nhất
        //Viết truy vấn LINQ để lấy sản phẩm có số lượng giao dịch kho hàng 'OUT' nhiều nhất.

        //Câu hỏi 7: Số lượng giao dịch theo từng loại
        //Viết truy vấn LINQ để lấy số lượng giao dịch kho hàng theo từng loại ('IN' và 'OUT').

        //Câu hỏi 8: Sản phẩm của nhà cung cấp trong thành phố cụ thể
        //Viết truy vấn LINQ để lấy tất cả các sản phẩm của nhà cung cấp trong một thành phố cụ thể(ví dụ: "New York").

        //Câu hỏi 9: Tổng số lượng và tổng giá trị hàng tồn kho theo danh mục
        //Viết truy vấn LINQ để lấy tổng số lượng và tổng giá trị hàng tồn kho(UnitPrice* UnitsInStock) theo từng danh mục.

        //Câu hỏi 10: Giao dịch kho hàng trong khoảng thời gian
        //Viết truy vấn LINQ để lấy tất cả các giao dịch kho hàng được thực hiện trong khoảng thời gian từ ngày 1 tháng 1 năm 2024 đến ngày 30 tháng 6 năm 2024.
    }
}
