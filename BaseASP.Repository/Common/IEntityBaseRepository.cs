using BaseASP.Model.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace BaseASP.Repository.Common
{
    public interface IEntityBaseRepository<T> where T : IEntityBase
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<IEnumerable<T>> GetAllNoTracking();
        Task<IEnumerable<T>> GetAllNoTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAllAsQueryable();

        Task<T> GetById(int id);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);

        Task<T> FindByCondition(Expression<Func<T, bool>> predicate);

        Task<EntityEntry> AddAsync(T entity);
        Task AddRange(IEnumerable<T> list);

        void Update(T t);

        void Destroy(T t);


        void SoftDelete(T t);
        void DeleteRange(IEnumerable<T> t);
        Task Save();
    }
}
