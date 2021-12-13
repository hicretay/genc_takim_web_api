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
    public class GameViewController : ControllerBase
    {
        private readonly ILogger<GameViewController> _logger;

        public GameViewController(ILogger<GameViewController> logger)
        {
            _logger = logger;
        }


        [HttpPost("UserGame/List")]
        public object PostGames([FromBody] games game)
        {
            try
            {
                object userResult = new GameView().DataSource(game.UserId);
                return new {succes=true,result = userResult};
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
