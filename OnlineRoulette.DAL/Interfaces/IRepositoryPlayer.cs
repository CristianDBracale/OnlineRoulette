using Online.Roulette.Entities;
using System.Collections.Generic;

namespace OnlineRoulette.DAL.Interfaces
{
    public interface IRepositoryPlayer : IRepository<Player>
    {
        string CreateNewPlayer();
        Player GetById(string playerId);
        List<Player> Get();
    }
}
