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

                object selectlocation = new GameUserTbl().SelectDifLocation(userGame.UserLocation,userGame.GameId);

                if(selectlocation == null) // seçili konumda kullanıcı var mı kontrolü
                {
                    object differentUserLocation = new GameUserTbl().SelectDifferentUserLocation(userGame.UserId, userGame.GameId);

                    if (differentUserLocation == null) // kullanıcı oyuna kayıtlı mı kontrolü
                    {
                        object userResult = new GameUserTbl().Save(u);
                        return new { succes = true, result = userResult };
                    }
                    else
                    {
                        return new { succes = false, result = "Kullanıcı bu oyuna daha önce kayıt olmuş !" };
                    }
                }

                else
                {
                    return new { succes = false, result = "Seçtiğiniz konumda başka bir kullanıcı kayıtlıdır !" };
                }
 
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpPost("UserMatch/ExistLocation")]
        public object ExistLocation([FromBody] gameUserL userGame)
        {
            try
            {
               var userResult = new GameUserView().ExistLocation(userGame.GameId);

                if (userResult != null)
                {
                    return new { succes = true, result = userResult };
                }
                
               else
                return new { succes = false, result = new List<GameUserViewDAO>() }; 

            }
            catch 
            {
                return new { succes = false, result =new List<GameUserViewDAO>() };
            }
        }
    }


}
