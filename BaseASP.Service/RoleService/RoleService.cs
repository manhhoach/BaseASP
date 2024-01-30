using BaseASP.Model.Entities;
using BaseASP.Repository.Common;
using BaseASP.Service.Common;

namespace BaseASP.Service.RoleService
{
    public class RoleService : EntityBaseService<Role>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IEntityBaseRepository<Role> repository) : base(unitOfWork, repository)
        {
        }
    }
}
