using Online.Roulette.Entities;
using System.Collections.Generic;

namespace OnlineRoulette.DAL.Interfaces
{
    public interface IRepositoryRoulette : IRepository<Roulette>
    {
        Roulette GetById(string id);
        string CreateNewRoulette();
        bool RouletteOpeningById(string id);
        long CloseBetsById(string id);
        List<Roulette> GetAll();
        string NewPlayerBet(Player player, Bet bet);
    }
}
