using Autofac;
using BaseASP.Model;
using BaseASP.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace BaseASP.API.Modules
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(AppDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
            builder.RegisterModule(new RepositoryModule());
        }
    }
}
