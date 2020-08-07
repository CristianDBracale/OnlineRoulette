using Online.Roulette.Entities;
using System.Collections.Generic;

namespace OnlineRoulette.Gateway.DataInterfaces
{
    public interface IRouletteBusiness
    {
        /// <summary>
        /// Returns roulette list
        /// </summary>
        /// <returns></returns>
        List<Roulette> GetAll();

        /// <summary>
        /// Return roulette by id
        /// </summary>
        /// <param name="id">Id of the roulette sought</param>
        /// <returns></returns>
        Roulette GetById(string id);

        /// <summary>
        /// Create new roulette
        /// </summary>
        /// <returns>Id of the roulette created</returns>
        string CreateNewRoulette();

        /// <summary>
        /// Roulette opening
        /// </summary>
        /// <param name="id">id of the roulette to open</param>
        /// <returns>Returns status confirming that the operation was successful or denied</returns>
        bool RouletteOpeningById(string id);

        /// <summary>
        /// Bet on a number or color on an open roulette wheel with a certain amount of money
        /// </summary>
        /// <param name="player">Entity Player</param>
        /// <param name="bet">Entity Bet</param>
        /// <returns>id of the roulette</returns>
        string NewPlayerBet(Player player, Bet bet);

        /// <summary>
        /// Close bets
        /// </summary>
        /// <param name="id">id of the roulette</param>
        /// <returns>Returns the result of the bets made</returns>
        long CloseBetsById(string id);
    }
}
