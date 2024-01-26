using Autofac;
using StackExchange.Redis;

namespace BaseASP.API.Modules
{
    public class RedisModule : Autofac.Module
    {
        private readonly IConfiguration _config;
        public RedisModule(IConfiguration config)
        {
            _config = config;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder
            .Register(cx => ConnectionMultiplexer.Connect($"{_config["Redis:Host"]}:{_config["Redis:Port"]}"))
            .As<IConnectionMultiplexer>()
            .SingleInstance();
            builder.Register(c => c.Resolve<IConnectionMultiplexer>()
                 .GetDatabase())
                 .As<IDatabase>()
                 .SingleInstance();
        }
    }
}
