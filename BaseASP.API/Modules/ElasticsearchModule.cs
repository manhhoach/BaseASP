using Autofac;
using BaseASP.Model;

namespace BaseASP.API.Modules
{
    public class ElasticsearchModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ElasticsearchContext>().AsSelf().SingleInstance();
        }
    }
}
