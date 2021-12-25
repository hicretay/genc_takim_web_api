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
                return new { succes = true, result = userResult };
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("Save")]
        public object SaveUser([FromBody] saveUser user)
        {
            try
            {
               
                var u = new UserTblDAO() 
                { 
       
                    UserName=user.UserName, 
                    UserEmail=user.UserEmail, 
                    UserPassword=user.UserPassword, 
                    UserTelephone=user.UserTelephone,
                    Birthdate=user.Birthdate
                };

                object differentUser = new UserTbl().SelectDifferentUser(user.UserEmail);

                
                if(differentUser == null)
                {
                    object userResult = new UserTbl().Save(u);
                    return new { succes = true, result = userResult };
                }
                else
                {
                    return "Kullanıcı daha önce kayıt olmuş !";
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}