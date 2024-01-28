using BaseASP.Model;
using BaseASP.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace BaseASP.Repository.Common
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : EntityBase
    {
        protected AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<EntityEntry> AddAsync(T entity)
        {
            return await _dbSet.AddAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.Where(t => !t.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.Where(t => !t.IsDeleted).Where(predicate);
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
        }

        public virtual async Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
        }

        public virtual void Update(T entity)
        {
            EntityEntry ee = _context.Entry<T>(entity);
            ee.State = EntityState.Modified;
            //  await _context.SaveChangesAsync();
        }

        public virtual void SoftDelete(T entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            //  await _context.SaveChangesAsync();

        }

        public virtual async Task<IEnumerable<T>> GetAllNoTracking()
        {
            return await _dbSet.Where(t => !t.IsDeleted).AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllNoTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.Where(t => !t.IsDeleted).Where(predicate).AsNoTracking();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public virtual async Task<List<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> FindOne(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task AddRange(IEnumerable<T> list)
        {
            await _dbSet.AddRangeAsync(list);
        }

        public virtual void Destroy(T entity)
        {
            EntityEntry ee = _context.Entry<T>(entity);
            ee.State = EntityState.Deleted;
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual IQueryable<T> GetAllAsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
