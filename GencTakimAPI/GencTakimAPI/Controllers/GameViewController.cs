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
    public class GamesListController : ControllerBase
    {
        private readonly ILogger<GamesListController> _logger;

        public GamesListController(ILogger<GamesListController> logger)
        {
            _logger = logger;
        }


        [HttpPost("Games/UserGameList")]
        public object PostUserGames([FromBody] games game)  
        {
            try
            {
                object userResult = new GameView().DataSource(game.UserId, game.IsPassed);
                return new {succes=true,result = userResult};
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("Games/AllMatchesList")]
        public object PostAllGames()   
        {
            try
            {
                object userResult = new GameView().DataSource();
                return new { succes = true, result = userResult };
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("Games/ComingMatchesList")]
        public object PostComingGames([FromBody] comingGames game)
        {
            try
            {
                object userResult = new GameView().DataSource(game.IsPassed);
                return new { succes = true, result = userResult };
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
