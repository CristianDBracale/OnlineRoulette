using OnlineRoulette.SharedTypes;
using System;

namespace OnlineRoulette.DTO
{
    public class RouletteDto
    {
        public Guid Id { get; set; }
        public RouletteStateEnum Status { get; set; }

        #region Constructors
        public RouletteDto(Guid id, RouletteStateEnum status)
        {
            Id = id;
            Status = status;
        }
        #endregion
    }
}
