using BaseASP.Model.Entities;
using BaseASP.Repository.Common;
using BaseASP.Service.Common;

namespace BaseASP.Service.CategoryService
{
    public class CategoryService : EntityBaseService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IEntityBaseRepository<Category> repository) : base(unitOfWork, repository)
        {
        }
    }
}
