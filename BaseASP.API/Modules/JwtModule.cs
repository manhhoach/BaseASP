using Autofac;
using BaseASP.Model;
using BaseASP.Repository.Common;
using BaseASP.Service.JwtService;
using Microsoft.EntityFrameworkCore;

namespace BaseASP.API.Modules
{
    public class JwtModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
          
            builder.RegisterType(typeof(JwtService)).As(typeof(IJwtService)).SingleInstance();
          
        }
    }
}
