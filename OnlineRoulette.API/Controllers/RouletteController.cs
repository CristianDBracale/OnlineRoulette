using Microsoft.AspNetCore.Mvc;
using Online.Roulette.Entities;
using OnlineRoulette.Gateway.DataInterfaces;
using System;

namespace OnlineRoulette.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteBusiness _rouletteBusiness;
        private readonly IPlayerBusiness _playerBusiness;

        #region Constructors
        public RouletteController(IRouletteBusiness rouletteBusiness, IPlayerBusiness playerBusiness)
        {
            _rouletteBusiness = rouletteBusiness;
            _playerBusiness = playerBusiness;
        }
        #endregion

        /// <summary>
        /// Endpoint 1. New roulette creation that returns the id of the new roulette created
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult Create()
        {
            try
            {
                string id = _rouletteBusiness.CreateNewRoulette();

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint 2. roulette opening (the input is a roulette id) that allows subsequent betting requests, it must simply return a state that confirms that the operation was successful or denied
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("RouletteOpeningById/{id}")]
        public IActionResult RouletteOpeningById(string id)
        {
            try
            {
                Roulette roulette = _rouletteBusiness.GetById(id: id);
                if (roulette == null)
                {
                    return NotFound("Ruleta no encontrada.");
                }
                bool result = _rouletteBusiness.RouletteOpeningById(id: id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint 3. Bet on a number (the valid numbers to bet are from 0 to 36) or color (black or red) of the roulette a certain amount of money (maximum $ 10,000) to an open roulette.
        /// (note: receive the parameters of the bet and a player id in the Headers assuming that the service that makes the request has already authenticated and validated that the player has the necessary credit to make the bet)
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="bet"></param>
        /// <returns></returns>
        [HttpPost("PlayerBet/{playerId}")]
        public IActionResult Bet(string playerId, Bet bet)
        {
            try
            {
                Player player = _playerBusiness.GetById(playerId: playerId);
                if (player == null)
                {
                    return NotFound("El jugador no se encuentra en esta ruleta");
                }
                string id = _rouletteBusiness.NewPlayerBet(player: player, bet: bet);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint 4. Close bets given a roulette id, this endpoint must return the result of bets made from opening to closing.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CloseBetsById/{id}")]
        public IActionResult CloseBetsById(string id)
        {
            try
            {
                decimal result = _rouletteBusiness.CloseBetsById(id: id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Roulette
        //[HttpGet("GetAll")]
        //public IActionResult GetAll()
        //{
        //    try
        //    {
        //        List<Roulette> roulettes = _rouletteBusiness.GetAll();
        //        List<RouletteDto> rouletteDtos = new List<RouletteDto>();
        //        foreach (Roulette roulette in roulettes)
        //        {
        //            rouletteDtos.Add(new RouletteDto(roulette.Id, roulette.State));
        //        }

        //        return Ok(rouletteDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
