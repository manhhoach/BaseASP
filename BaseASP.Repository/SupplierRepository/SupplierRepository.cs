using BaseASP.Model;
using BaseASP.Model.Entities;
using BaseASP.Repository.Common;

namespace BaseASP.Repository.SupplierRepository
{
    public class SupplierRepository : EntityBaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext context) : base(context) { }
    }
}
