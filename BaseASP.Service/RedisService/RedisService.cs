
using StackExchange.Redis;

namespace BaseASP.Service.RedisService
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _db;
        public RedisService(IDatabase db)
        {
            _db = db;
        }

        public string Get(string key)
        {
            return _db.StringGet(key);
        }

        public void Set(string key, string value)
        {
            _db.StringSet(key, value);
        }
    }
}
