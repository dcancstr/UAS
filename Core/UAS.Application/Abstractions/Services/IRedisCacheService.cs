using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Abstractions.Services
{
    public interface IRedisCacheService
    {
        Task<T> GetFromRedis<T>(string key);
        Task<List<T>> GetAllFromRedis<T>(List<string> keys);
        Task<bool> SetToRedis<T>(string key, T value, DateTimeOffset expirationTime);
        Task<bool> RemoveFromRedis(string key);
        Task SetToRedisList<T>(Dictionary<string, T> keyValuePairs, DateTimeOffset expirationTime);
        Task<bool> SetToRedis<T>(string key, T value);

    }
}
