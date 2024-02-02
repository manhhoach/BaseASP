using BaseASP.Model.Common;
using System.Linq.Expressions;

namespace BaseASP.Service.Common
{
    public interface IEntityBaseService<T> where T : EntityBase
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

        Task AddAsync(T t);
        Task AddRangeAsync(IEnumerable<T> list);

        Task UpdateAsync(T t);

        Task DestroyAsync(int id);


        Task SoftDeleteAsync(int id);
        Task DeleteRangeAsync(List<int> ids);
    }
}
