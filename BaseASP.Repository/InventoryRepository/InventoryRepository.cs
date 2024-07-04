using BaseASP.Model;
using BaseASP.Model.Entities;
using BaseASP.Repository.Common;

namespace BaseASP.Repository.InventoryRepository
{
    public class InventoryRepository : EntityBaseRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(AppDbContext context) : base(context) { }
    }
}
