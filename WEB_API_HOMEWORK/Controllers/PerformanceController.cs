using Microsoft.AspNetCore.Mvc;
using WEB_API_HOMEWORK.Interfaces;

namespace WEB_API_HOMEWORK.Controllers
{
    public class PerformanceController : ControllerBase
    {
        private readonly IPerformanceService _performanceService;

        public PerformanceController(IPerformanceService performanceService)
        {
            _performanceService = performanceService;

        }
        [HttpGet]
        [Route("api/getperformance/{count}")]
        public IActionResult GetPerformanceMeasures(int count)
        {      // Get performance measures with chosen array size
            try
            {
                return Ok(_performanceService.ReturnPerformanceResults(count));
            }
            catch (Exception e)
            {
                return BadRequest("Error while fetching performance data: " + e.Message);
            }
        }
        
    }
}
