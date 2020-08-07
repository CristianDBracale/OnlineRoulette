using OnlineRoulette.Enums;
using System;

namespace Online.Roulette.Entities
{
    public class Bet
    {
        public Guid Id { get; set; }

        public BetTypeEnum BetType { get; set; }

        public int? Number { get; set; }

        /// <summary>
        /// 1: black,
        /// 0: red 
        /// </summary>
        public short? Color { get; set; }

        public long Value { get; set; }

        public Guid IdRoulette { get; set; }

        #region Constructors
        public Bet() { }

        public Bet(Guid id, BetTypeEnum betType, int? number, short? color, long value, Guid idRoulette)
        {
            Id = id;
            BetType = betType;
            Number = number;
            Color = color;
            Value = value;
            IdRoulette = idRoulette;
        }

        public void GenerateNewId()
        {
            Id = Guid.NewGuid();
        }
        #endregion
    }
}
