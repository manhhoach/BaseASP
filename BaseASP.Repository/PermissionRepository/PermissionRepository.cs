using BaseASP.Model;
using BaseASP.Model.Entities;
using BaseASP.Repository.Common;

namespace BaseASP.Repository.PermissionRepository
{
    public class PermissionRepository : EntityBaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext context) : base(context) { }
    }
}
