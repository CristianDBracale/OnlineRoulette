using System;
using System.Collections.Generic;

namespace Online.Roulette.Entities
{
    public class Roulette
    {
        public Guid Id { get; set; }
        public bool State { get; set; }
        public List<Bet> Bets { get; set; } = new List<Bet>();

        #region Constructors
        public Roulette() { }

        public Roulette(bool estado)
        {
            Id = Guid.NewGuid();
            State = estado;
        }
        #endregion
    }
}
