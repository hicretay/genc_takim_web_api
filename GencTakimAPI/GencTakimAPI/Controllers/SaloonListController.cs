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
    public class SaloonListController : ControllerBase
    {
        private readonly ILogger<SaloonListController> _logger;

        public SaloonListController(ILogger<SaloonListController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public object PostSaloons() 
        {
            try
            {
                object userResult = new SaloonTbl().DataSource();
                return new { succes = true, result = userResult };
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
