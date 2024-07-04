using BaseASP.Model.Entities;
using BaseASP.Repository.Common;
using BaseASP.Service.Common;

namespace BaseASP.Service.SupplierService
{
    public class SupplierService : EntityBaseService<Supplier>, ISupplierService
    {
        public SupplierService(IUnitOfWork unitOfWork, IEntityBaseRepository<Supplier> repository) : base(unitOfWork, repository)
        {
        }
    }
}
