using OnlineRoulette.Persistence.Interfaces;
using StackExchange.Redis;
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

        #region Constructors
        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _multiplexer = connectionMultiplexer;
        }

        #endregion
    }
}
