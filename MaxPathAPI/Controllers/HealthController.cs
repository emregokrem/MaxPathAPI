using MaxPath.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaxPathAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly ILoggerManager _loggerManager;
        public HealthController(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }
        // GET: api/<HealthController>
        [HttpGet]
        public string Get()
        {
            _loggerManager.LogInfo("Health Controller - Get Called!");
            return "The Service Is Healthy!";
        }
    }
}
