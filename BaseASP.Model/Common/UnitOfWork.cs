using BaseASP.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BaseASP.Repository.Common
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Commit()
        {
            await dbContext.SaveChangesAsync();
        }

        public DbContext Context()
        {
            return dbContext;
        }

        public IDbContextTransaction CreateTransaction()
        {
            return dbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                    dbContext = null;
                }
            }
        }
    }
}
