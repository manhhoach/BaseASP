using BaseASP.Model;
using BaseASP.Model.Entities;
using BaseASP.Repository.Common;

namespace BaseASP.Repository.ProductRepository
{
    public class ProductRepository : EntityBaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
    }
}
