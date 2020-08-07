using OnlineRoulette.SharedTypes;
using System;
using System.Collections.Generic;

namespace Online.Roulette.Entities
{
    public class Roulette
    {
        public Guid Id { get; set; }
        public RouletteStateEnum State { get; set; }
        public List<Bet> Bets { get; set; } = new List<Bet>();

        #region Constructors
        public Roulette()
        {
            Id = Guid.NewGuid();
            State = RouletteStateEnum.Close;
        }

        public void ChangeStateOpen()
        {
            State = RouletteStateEnum.Open;
        }

        public void ChangeStateClose()
        {
            State = RouletteStateEnum.Close;
        }
        #endregion
    }
}
