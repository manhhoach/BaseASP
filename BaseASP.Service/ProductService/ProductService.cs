using BaseASP.Model.Entities;
using BaseASP.Repository.Common;
using BaseASP.Service.Common;

namespace BaseASP.Service.ProductService
{
    public class ProductService : EntityBaseService<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IEntityBaseRepository<Product> repository) : base(unitOfWork, repository)
        {
        }
    }
}
