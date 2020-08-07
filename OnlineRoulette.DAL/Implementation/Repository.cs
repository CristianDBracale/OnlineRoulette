using EasyCaching.Core;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Online.Roulette.Entities;
using OnlineRoulette.DAL.Interfaces;
using ServiceStack;
using System.Collections.Generic;

namespace OnlineRoulette.DAL.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDistributedCache _cacheName;
        private readonly string _cacheKey;

        private IEasyCachingProvider _cachingProvider;

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

        public List<TEntity> GetAllObjects()
        {
            IDictionary<string, CacheValue<Roulette>> iDictionaryRouletes = _cachingProvider.GetByPrefix<Roulette>("roulettes");
            List<TEntity> listRoulettes = new List<TEntity>();
            foreach (KeyValuePair<string, CacheValue<Roulette>> cacheValue in iDictionaryRouletes)
            {
                string cacheKey = $"{cacheValue.Key}";
                string cacheName = _cacheName.GetString(key: cacheKey);
                var roulette = JsonConvert.DeserializeObject<TEntity>(cacheName);
                listRoulettes.Add(roulette);
            }

            return listRoulettes;
        }

        #region Constructors
        public Repository(IDistributedCache cache, string cacheKey, IEasyCachingProvider cachingProvider)
        {
            _cacheName = cache;
            _cacheKey = cacheKey;
            _cachingProvider = cachingProvider;
        }
        #endregion
    }
}
