using BaseASP.Model.Entities;
using BaseASP.Repository.Common;
using BaseASP.Service.Common;

namespace BaseASP.Service.UserService
{
    public class UserService : EntityBaseService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IEntityBaseRepository<User> repository) : base(unitOfWork, repository)
        {
        }
    }
}
