using System;
using System.Collections.Generic;
using System.Text;

namespace Online.Roulette.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public long Balance { get; set; }
        public List<Bet> Bets { get; set; } = new List<Bet>();

        #region Constructors
        public Player()
        {
            Id = Guid.NewGuid();
            Balance = 0;
        }
        #endregion
    }
}
