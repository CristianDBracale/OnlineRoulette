using Microsoft.AspNetCore.Mvc;
using Online.Roulette.Entities;
using OnlineRoulette.Gateway.DataInterfaces;
using System;

namespace OnlineRoulette.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerBusiness _iPlayerBusiness;

        #region Constructors
        public PlayerController(IPlayerBusiness iPlayerBusiness)
        {
            _iPlayerBusiness = iPlayerBusiness;
        }
        #endregion

        /// <summary>
        /// Create new player
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("CreateNewPlayer")]
        public IActionResult Post()
        {
            try
            {
                string playerId = _iPlayerBusiness.CreateNewPlayer();

                return Ok(playerId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}