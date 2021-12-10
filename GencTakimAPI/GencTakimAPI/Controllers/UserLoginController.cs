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
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }


        [HttpPost("Login")]
        public object PostUsers([FromBody] userLogin userLogin)
        {
            try
            {
                object userResult = new UserTbl().Select(userLogin.UserEmail, userLogin.UserPassword);
                return userResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost("Login/kaydet")]
        public object Kaydet([FromBody] userKaydet user)
        {
            try
            {
                var u = new UserTblDAO() { Id = user.Id, UserName=user.UserName};
                object userResult = new UserTbl().Save(u);
                return userResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
