using Online.Roulette.Entities;
using OnlineRoulette.DAL.Interfaces;
using OnlineRoulette.Gateway.DataInterfaces;

namespace OnlineRoulette.Gateway.Business
{
    public class PlayerBusiness : IPlayerBusiness
    {
        private readonly IRepositoryPlayer _iRepositoryPlayer;

        public string CreateNewPlayer()
        {
            return _iRepositoryPlayer.CreateNewPlayer();
        }

        public Player GetById(string playerId)
        {
            return _iRepositoryPlayer.GetById(playerId: playerId);
        }

        #region Constructors
        public PlayerBusiness(IRepositoryPlayer repositoryPlayer)
        {
            _iRepositoryPlayer = repositoryPlayer;
        }
        #endregion
    }
}
