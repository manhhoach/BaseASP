using Autofac;
using AutoMapper;

namespace BaseASP.API.Modules
{
    public class AutoMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(MapperProfile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<MapperProfile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (MapperProfile profile in c.Resolve<IEnumerable<MapperProfile>>())
                {
                    cfg.AddProfile(profile);
                }
                cfg.AllowNullDestinationValues = true;
            })).AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();

        }


    }
}
