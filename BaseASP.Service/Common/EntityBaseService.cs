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

        public async Task AddAsync(T t)
        {
            await _repository.AddAsync(t);
            await _unitOfWork.Commit();
        }

        public async Task AddRangeAsync(IEnumerable<T> list)
        {
            await _repository.AddRangeAsync(list);
            await _unitOfWork.Commit();
        }

        public async Task DeleteRangeAsync(List<int> ids)
        {
            var entities = await _repository.GetAllAsync(e => ids.Contains(e.Id));
            _repository.DeleteRange(entities);
            await _unitOfWork.Commit();
        }

        public async Task DestroyAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            _repository.Destroy(entity);
            await _unitOfWork.Commit();
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FindOneAsync(predicate);
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FindAllAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _repository.GetAllAsync(predicate, includeProperties);
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return _repository.GetAllAsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllNoTrackingAsync()
        {
            return await _repository.GetAllNoTrackingAsync();
        }

        public async Task<IEnumerable<T>> GetAllNoTrackingAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _repository.GetAllNoTrackingAsync(predicate, includeProperties);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _repository.GetByIdAsync(id, includeProperties);
        }

        public async Task SoftDeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            _repository.SoftDelete(entity);
            await _unitOfWork.Commit();
        }

        public async Task UpdateAsync(T t)
        {
            _repository.Update(t);
            await _unitOfWork.Commit();
        }
    }
}
