using BaseASP.Model.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace BaseASP.Repository.Common
{
    public interface IEntityBaseRepository<T> where T : IEntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<IEnumerable<T>> GetAllNoTrackingAsync();
        Task<IEnumerable<T>> GetAllNoTrackingAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAllAsQueryable();

        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);

        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate);

        Task<EntityEntry> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> list);

        void Update(T t);

        void Destroy(T t);

        T GetById(int id);

        void SoftDelete(T t);
        void DeleteRange(IEnumerable<T> t);
        Task SaveAsync();
    }
}
