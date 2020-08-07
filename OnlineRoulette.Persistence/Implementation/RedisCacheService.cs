using OnlineRoulette.Persistence.Interfaces;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRoulette.Persistence.Implementation
{
    public class RedisCacheService : ICacheManager
    {
        private readonly IConnectionMultiplexer _multiplexer;

        public async Task<string> Get<T>(string key)
        {
            IDatabase db = _multiplexer.GetDatabase();

            return await db.StringGetAsync(key: key);
        }

        public async Task Save(string key, string value)
        {
            var db = _multiplexer.GetDatabase();
            await db.StringSetAsync(key: key, value: value);
        }

        public IEnumerable<KeyValuePair<string, object>> GetAll()
        {
            var result = new List<KeyValuePair<string, object>>();
            var endpoints = _multiplexer.GetEndPoints();
            var server = _multiplexer.GetServer(endpoint: endpoints.First());

            var keys = server.Keys(database: 0);
            foreach (var key in keys)
            {
                result.Add(new KeyValuePair<string, object>(key: key.ToString(),value: key));
            }
            return result;
        }

        #region Constructors
        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _multiplexer = connectionMultiplexer;
        }

        #endregion
    }
}
