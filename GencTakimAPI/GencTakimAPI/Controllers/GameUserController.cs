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


        //[HttpPost("Match/Save")]
        //public object SaveUser([FromBody] addGame userGame)
        //{
        //    try
        //    {
        //        var u = new GameUserTblDAO()
        //        {
        //            UserId = userGame.UserId,
        //            GameId = userGame.GameId,
        //            GamePlayTime = userGame.GamePlayTime,
        //            IsSubstitute = userGame.IsSubstitute,
        //            UserLocation = userGame.UserLocation
        //        };

        //        object userResult = new GameUserTbl().Save(u);
        //        return new { succes = true, result = userResult };
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}
