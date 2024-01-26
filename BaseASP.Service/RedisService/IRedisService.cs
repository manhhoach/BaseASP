namespace BaseASP.Service.RedisService
{
    public interface IRedisService
    {
        string Get(string key);
        void Set(string key, string value);
    }
}
