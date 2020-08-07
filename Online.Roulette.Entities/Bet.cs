using System;
using Online.Roulette.SharedTypes;

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
    }
}
