using BaseASP.Model.Entities;
using BaseASP.Repository.Common;
using BaseASP.Service.Common;

namespace BaseASP.Service.PermissionService
{
    public class CategoryService : EntityBaseService<Permission>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IEntityBaseRepository<Permission> repository) : base(unitOfWork, repository)
        {
        }
    }
}
