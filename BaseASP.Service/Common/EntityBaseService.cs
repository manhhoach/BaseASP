using BaseASP.Model.Common;
using BaseASP.Repository.Common;
using System.Linq.Expressions;

namespace BaseASP.Service.Common
{
    public class EntityBaseService<T> : IEntityBaseService<T> where T : EntityBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityBaseRepository<T> _repository;
        public EntityBaseService(IUnitOfWork unitOfWork, IEntityBaseRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task Add(T t)
        {
            await _repository.AddAsync(t);
            await _unitOfWork.Commit();
        }

        public async Task AddRange(IEnumerable<T> list)
        {
            await _repository.AddRange(list);
            await _unitOfWork.Commit();
        }

        public async Task DeleteRange(List<int> ids)
        {
            var entities = await _repository.GetAll(e => ids.Contains(e.Id));
            _repository.DeleteRange(entities);
            await _unitOfWork.Commit();
        }

        public async Task Destroy(int id)
        {
            var entity = await _repository.GetById(id);
            _repository.Destroy(entity);
            await _unitOfWork.Commit();
        }

        public async Task<T> FindOne(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FindOne(predicate);
        }

        public async Task<List<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FindAll(predicate);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _repository.GetAll(predicate, includeProperties);
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return _repository.GetAllAsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllNoTracking()
        {
            return await _repository.GetAllNoTracking();
        }

        public async Task<IEnumerable<T>> GetAllNoTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _repository.GetAllNoTracking(predicate, includeProperties);
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _repository.GetById(id, includeProperties);
        }

        public async Task SoftDelete(int id)
        {
            var entity = await _repository.GetById(id);
            _repository.SoftDelete(entity);
            await _unitOfWork.Commit();
        }

        public async Task Update(T t)
        {
            _repository.Update(t);
            await _unitOfWork.Commit();
        }
    }
}
