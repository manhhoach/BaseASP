using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BaseASP.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
        IDbContextTransaction CreateTransaction();
        DbContext Context();

    }
}
