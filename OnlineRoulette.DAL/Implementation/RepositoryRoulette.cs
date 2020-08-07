using EasyCaching.Core;
using Microsoft.Extensions.Caching.Distributed;
using Online.Roulette.Entities;
using OnlineRoulette.DAL.Interfaces;
using OnlineRoulette.Enums;
using OnlineRoulette.SharedTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRoulette.DAL.Implementation
{
    public class RepositoryRoulette : Repository<Roulette>, IRepositoryRoulette
    {
        public RepositoryRoulette(IDistributedCache cache, IEasyCachingProvider cachingProvider)
            : base(cache, "roulettes", cachingProvider) { }

        public long CloseBetsById(string id)
        {
            Roulette roulette = GetObjectAsync(idRoulette: id);
            if (roulette == null)
            {
                throw new Exception("Ruleta no existente");
            }
            roulette.ChangeStateClose();
            SetObjectAsync(idRoulette: roulette.Id.ToString(), objectToCache: roulette);
            long result = roulette.Bets.Sum(x => x.Value);

            return result;
        }

        public string CreateNewRoulette()
        {
            Roulette newRoulette = new Roulette();
            SetObjectAsync(idRoulette: newRoulette.Id.ToString(), objectToCache: newRoulette);

            return newRoulette.Id.ToString();
        }

        public List<Roulette> GetAll()
        {
            return GetAllObjects();
        }

        public Roulette GetById(string id)
        {
            Roulette roulette = GetObjectAsync(id);

            return roulette;
        }

        public string NewPlayerBet(Player player, Bet bet)
        {
            if (bet.BetType.Equals(BetTypeEnum.Number))
            {
                if (bet.Number.Value < 0 || bet.Number.Value > 36)
                {
                    throw new Exception("El número se encuentra fuera de rango.");
                }
            }
            else
            {
                if (bet.Color.Value < 0 || bet.Color.Value > 1)
                {
                    throw new Exception("El color no pertenece a uno valido.");
                }
            }
            if (bet.Value > 10000)
            {
                throw new Exception("Apuesta maxima de $10.000");
            }
            Roulette roulette = GetObjectAsync(bet.IdRoulette.ToString());
            if (roulette == null)
            {
                throw new Exception("La ruleta no existe.");
            }
            if (roulette.State == RouletteStateEnum.Close)
            {
                throw new Exception("La ruleta no se encuentra abierta.");
            }
            bet.GenerateNewId();
            roulette.Bets.Add(bet);
            SetObjectAsync(roulette.Id.ToString(), roulette);

            return bet.Id.ToString();
        }

        public bool RouletteOpeningById(string id)
        {
            Roulette roulette = GetObjectAsync(id);
            roulette.ChangeStateOpen();
            SetObjectAsync(roulette.Id.ToString(), roulette);

            return true;
        }
    }
}
