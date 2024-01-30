using BaseASP.Model.Entities;
using BaseASP.Repository.Common;
using BaseASP.Service.Common;

namespace BaseASP.Service.PermissionService
{
    public class PermissionService : EntityBaseService<Permission>, IPermissionService
    {
        public PermissionService(IUnitOfWork unitOfWork, IEntityBaseRepository<Permission> repository) : base(unitOfWork, repository)
        {
        }
    }
}
