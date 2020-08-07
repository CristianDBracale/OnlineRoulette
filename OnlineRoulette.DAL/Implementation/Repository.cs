using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using OnlineRoulette.DAL.Interfaces;
using ServiceStack;

namespace OnlineRoulette.DAL.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDistributedCache _cacheName;
        private readonly string _cacheKey;

        public TEntity GetObjectAsync(string idRoulette)
        {
            string cacheKey = $"{_cacheKey}.{idRoulette}";
            string cacheName = _cacheName.GetString(key: cacheKey);
            if (string.IsNullOrWhiteSpace(cacheName))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<TEntity>(cacheName);
        }

        public void SetObjectAsync(string idRoulette, TEntity objectToCache)
        {
            string cacheKey = $"{_cacheKey}.{idRoulette}";
            string serializedObjectToCache = JsonConvert.SerializeObject(value: objectToCache);
            _cacheName.SetString(key: cacheKey, value: serializedObjectToCache);
        }

        #region Constructors
        public Repository(IDistributedCache cache, string cacheKey)
        {
            _cacheName = cache;
            _cacheKey = cacheKey;
        }
        #endregion
    }
}
