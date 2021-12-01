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
    public class SportsListController : ControllerBase
    {
        private readonly ILogger<SportsListController> _logger;

        public SportsListController(ILogger<SportsListController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public object PostSports()       
        {
            try
            {
                object userResult = new SportTbl().DataSource();
                return userResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
