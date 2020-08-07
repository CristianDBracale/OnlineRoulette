using Online.Roulette.Entities;
using OnlineRoulette.DAL.Interfaces;
using OnlineRoulette.Gateway.DataInterfaces;
using System.Collections.Generic;

namespace OnlineRoulette.Gateway.Business
{
    public class RouletteBusiness : IRouletteBusiness
    {
        private readonly IRepositoryRoulette _iRepositoryRoulette;

        public long CloseBetsById(string id)
        {
            return _iRepositoryRoulette.CloseBetsById(id: id);
        }

        public string CreateNewRoulette()
        {
            return _iRepositoryRoulette.CreateNewRoulette();
        }

        public List<Roulette> GetAll()
        {
            return _iRepositoryRoulette.GetAll();
        }

        public Roulette GetById(string id)
        {
            return _iRepositoryRoulette.GetById(id: id);
        }

        public string NewPlayerBet(Player player, Bet bet)
        {
            return _iRepositoryRoulette.NewPlayerBet(player: player, bet: bet);
        }

        public bool RouletteOpeningById(string id)
        {
            return _iRepositoryRoulette.RouletteOpeningById(id: id);
        }

        #region Constructors
        public RouletteBusiness(IRepositoryRoulette iRepositoryRoulette)
        {
            _iRepositoryRoulette = iRepositoryRoulette;
        }
        #endregion
    }
}
