using AEDBGencTakimDataBaseEntity.DAO;
using AEDBGencTakimDataBaseEntity.Transactions;
using GencTakimAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GencTakimAPI.Controllers
{
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }


        //[HttpPost("Games/List")]
        //public object PostGames([FromBody] games game)
        //{
        //    try
        //    {
        //        object userResult = new GameTbl().DataSource(game.UserId);
        //        return userResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        [HttpPost("Match/Save")]
        public object SaveGame([FromBody] addGame userGame) 
        {
            try
            {
                var u = new GameTblDAO()
                {
                    UserId = userGame.UserId,
                    SportId = userGame.SportId,
                    SaloonId = userGame.SaloonId,
                    GameNote = userGame.GameNote,
                    GamePassed = userGame.GamePassed,
                    GameTime = userGame.GameTime,
                    GamePlayerCount = userGame.GamePlayerCount,
                    GameSubstituteCount = userGame.GameSubstituteCount
                };

                object userResult = new GameTbl().Save(u);
                return new { succes = true, result = userResult };
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
