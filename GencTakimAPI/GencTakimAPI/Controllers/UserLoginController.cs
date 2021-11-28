using AEDBGencTakimDataBaseEntity.Transactions;
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
    public class UserLoginController : ControllerBase
    {
        private readonly ILogger<UserLoginController> _logger;

        public UserLoginController(ILogger<UserLoginController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public object PostUsers()
        {
            try
            {
                var userList = new List<UserLoginController>();
                var userResult = new UserTbl().DataSource();
                return userResult;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
