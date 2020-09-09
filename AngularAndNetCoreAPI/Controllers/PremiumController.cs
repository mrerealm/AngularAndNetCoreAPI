using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AngularAndNetCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PremiumController : ControllerBase
    {
       
        private readonly ILogger<PremiumController> _logger;

        public PremiumController(ILogger<PremiumController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
