using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.EnvironmentConfiguration;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;

namespace UAS.Persistence.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly EnvironmentConfig _environmentConfig;
        IDatabase _cacheDb;

        public RedisCacheService(EnvironmentConfig environmentConfig)
        {
            this._environmentConfig = environmentConfig;
            var port = _environmentConfig.GetAppSetting<string>("RedisOptions:Port");
            var redis = ConnectionMultiplexer.Connect(port);
            _cacheDb = redis.GetDatabase();
        }

        public async Task<List<T>> GetAllFromRedis<T>(List<string> keys)
        {
            var data = new List<T>();
            foreach (var item in keys)
            {
                var result = System.Text.Json.JsonSerializer.Deserialize<T>(item);
                data.Add(result);

            }
            return data;
        }

        public async Task<T> GetFromRedis<T>(string key)
        {
            var result = _cacheDb.StringGet(key);
            if (!string.IsNullOrEmpty(result))
                return System.Text.Json.JsonSerializer.Deserialize<T>(result);

            return default;


        }

        public async Task<bool> RemoveFromRedis(string key)
        {
            if (_cacheDb.KeyExists(key))
                return await _cacheDb.KeyDeleteAsync(key);

            return false;
        }

        public async Task<bool> SetToRedis<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var exipireTime = expirationTime.DateTime.Subtract(DateTime.Now);
            
            return await _cacheDb.StringSetAsync(key, System.Text.Json.JsonSerializer.Serialize(value), exipireTime);
            
        }       
        public async Task<bool> SetToRedis<T>(string key, T value)
        {

            return await _cacheDb.StringSetAsync(key, System.Text.Json.JsonSerializer.Serialize(value));

        }

        public async Task SetToRedisList<T>(Dictionary<string, T> keyValuePairs, DateTimeOffset expirationTime)
        {
            foreach (var item in keyValuePairs)
            {
                var exipireTime = expirationTime.DateTime.Subtract(DateTime.Now);
                await _cacheDb.StringSetAsync(item.Key, System.Text.Json.JsonSerializer.Serialize(item.Value), exipireTime);
            }
        }
    }
}
