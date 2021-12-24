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
    public class UserGamesListController : ControllerBase
    {
        private readonly ILogger<UserGamesListController> _logger;

        public UserGamesListController(ILogger<UserGamesListController> logger)
        {
            _logger = logger;
        }


        [HttpPost("UserGames/UserGamesList")]
        public object PostUserGames([FromBody] games game)  
        {
            try
            {
                object userResult = new GameUserView().DataSource(game.UserId, game.IsPassed);
                return new {succes=true,result = userResult};
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
