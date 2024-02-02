using BaseASP.Model.Entities;
using BaseASP.Repository.Common;
using BaseASP.Repository.UserRepository;
using BaseASP.Service.Common;

namespace BaseASP.Service.UserService
{
    public class UserService : EntityBaseService<User>, IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository repository) : base(unitOfWork, repository)
        {
            _repository =  repository;
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
