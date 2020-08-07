using Online.Roulette.Entities;

namespace OnlineRoulette.Gateway.DataInterfaces
{
    public interface IPlayerBusiness
    {
        /// <summary>
        /// Create a new player
        /// </summary>
        /// <returns></returns>
        string CreateNewPlayer();

        /// <summary>
        /// Get Player by Id
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>Player</returns>
        Player GetById(string playerId);
    }
}
