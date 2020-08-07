using OnlineRoulette.SharedTypes;
using System;

namespace OnlineRoulette.DTO
{
    public class RouletteDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }

        #region Constructors
        public RouletteDto(Guid id, string status)
        {
            Id = id;
            Status = status;
        }
        #endregion
    }
}
