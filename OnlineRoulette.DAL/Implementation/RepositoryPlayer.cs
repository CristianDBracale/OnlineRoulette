using EasyCaching.Core;
using Microsoft.Extensions.Caching.Distributed;
using Online.Roulette.Entities;
using OnlineRoulette.DAL.Interfaces;
using System.Collections.Generic;

namespace OnlineRoulette.DAL.Implementation
{
    public class RepositoryPlayer : Repository<Player>, IRepositoryPlayer
    {
        public RepositoryPlayer(IDistributedCache cache, IEasyCachingProvider cachingProvider)
            : base(cache, "players", cachingProvider) { }

        public string CreateNewPlayer()
        {
            Player newPlayer = new Player();
            SetObjectAsync(idRoulette: newPlayer.Id.ToString(), objectToCache: newPlayer);

            return newPlayer.Id.ToString();
        }

        public Player GetById(string playerId)
        {
            return GetObjectAsync(idRoulette: playerId);
        }

        public List<Player> Get()
        {
            return null;
        }
    }
}
