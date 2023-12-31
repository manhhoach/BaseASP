using BaseASP.Model.Common;
using System.Linq.Expressions;

namespace BaseASP.Service.Common
{
    public interface IEntityBaseService<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<IEnumerable<T>> GetAllNoTracking();
        Task<IEnumerable<T>> GetAllNoTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAllAsQueryable();

        Task<T> GetById(int id);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);

        Task<T> FindByCondition(Expression<Func<T, bool>> predicate);

        Task Add(T t);
        Task AddRange(IEnumerable<T> list);

        Task Update(T t);

        Task Destroy(int id);


        Task SoftDelete(int id);
        Task DeleteRange(List<int> ids);
    }
}
