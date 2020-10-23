using System;
using MatxPath.Operation.Service;
using MaxPath.Domain.Entity;
using MaxPath.Domain.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MaxPath.Infrastructure.Extensions;

namespace MaxPathAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        private readonly ITriangleService _triangleService;
        private readonly ILoggerManager _loggerManager;

        public TriangleController(ITriangleService triangleService, ILoggerManager loggerManager)
        {
            _triangleService = triangleService;
            _loggerManager = loggerManager;
        }


        [HttpPost]
        public Triangle CalculateTriangle(TriangleRequest request)
        {
            _loggerManager.LogInfo("TriangleController/CalculateTriangle method is called!");

            if (request == null)
            {
                _loggerManager.LogError("Triangle Request is null!");
                throw new Exception("Triangle Request is null!");
            }

            return _triangleService.CalculateTriangle(request);
        }
    }
}
