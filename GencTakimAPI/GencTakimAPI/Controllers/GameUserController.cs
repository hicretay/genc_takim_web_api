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
    public class GameUserController : ControllerBase
    {
        private readonly ILogger<GameUserController> _logger;

        public GameUserController(ILogger<GameUserController> logger)
        {
            _logger = logger;
        }


        [HttpPost("UserMatch/Delete")]
        public object DeleteUserGames([FromBody] deleteUserGame game)
        {
            try
            {
                object userResult = new GameUserTbl().Delete(game.Id);
                return new { succes = true, result = userResult };
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("UserMatch/Save")]
        public object SaveGame([FromBody] addUserGame userGame)
        {
            try
            {
                var u = new GameUserTblDAO()
                {
                    UserId = userGame.UserId,
                    GameId = userGame.GameId,
                    UserLocation = userGame.UserLocation,
                    IsSubstitute = userGame.IsSubstitute,
                };

                object userResult = new GameUserTbl().Save(u);
                return new { succes = true, result = userResult };
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
