using BaseASP.Model.Entities;
using BaseASP.Repository.Common;
using BaseASP.Service.Common;

namespace BaseASP.Service.InventoryService
{
    public class InventoryService : EntityBaseService<Inventory>, IInventoryService
    {
        public InventoryService(IUnitOfWork unitOfWork, IEntityBaseRepository<Inventory> repository) : base(unitOfWork, repository)
        {
        }
    }
}
