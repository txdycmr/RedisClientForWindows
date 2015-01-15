using RedisDemo.Constant;
using ServiceStack.Redis;

namespace RedisDemo.RedisHelper
{
    public class RedisManager
    {
        private static readonly RedisConfigInfo RedisConfigInfo = RedisConfigInfo.GetConfig(Constants.ConfigSectionName);
        private static PooledRedisClientManager _pooledRedisClientManager;

        static RedisManager()
        {
            CreateManager();
        }

        private static void CreateManager()
        {
            var writeServerList = RedisConfigInfo.WriteServerList.Split(',');
            var readServerList = RedisConfigInfo.ReadServerList.Split(',');
            _pooledRedisClientManager = new PooledRedisClientManager(readServerList, writeServerList,
                            new RedisClientManagerConfig
                            {
                                MaxWritePoolSize = RedisConfigInfo.MaxWritePoolSize,
                                MaxReadPoolSize = RedisConfigInfo.MaxReadPoolSize,
                                AutoStart = RedisConfigInfo.AutoStart,
                            });
        }

        public static IRedisClient GetClient()
        {
            if (_pooledRedisClientManager == null)
            {
                CreateManager();
            }

            if (_pooledRedisClientManager != null)
            {
                return _pooledRedisClientManager.GetClient();
            }
            return null;
        }
    }
}
