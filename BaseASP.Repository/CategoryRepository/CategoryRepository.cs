using BaseASP.Model;
using BaseASP.Model.Entities;
using BaseASP.Repository.Common;

namespace BaseASP.Repository.CategoryRepository
{
    public class CategoryRepository : EntityBaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }
    }
}
