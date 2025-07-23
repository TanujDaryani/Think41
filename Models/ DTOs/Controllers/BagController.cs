using Microsoft.AspNetCore.Mvc;
using Think41.BaggageAPI.Services;

namespace Think41.BaggageAPI.Controllers
{
    [ApiController]
    [Route("api/baggage")]
    public class BagController : ControllerBase
    {
        private readonly IBagService _bagService;

        public BagController(IBagService bagService)
        {
            _bagService = bagService;
        }

        [HttpGet("scans/bag/{bagTagId}")]
        public async Task<IActionResult> GetLastScan(string bagTagId, [FromQuery] bool latest = true)
        {
            if (!latest) return BadRequest("Set latest=true to get last known location.");

            var result = await _bagService.GetLastLocationAsync(bagTagId);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("active/gate/{destinationGate}")]
        public async Task<IActionResult> GetBagsEnroute(string destinationGate, [FromQuery] int since_minutes = 60)
        {
            var result = await _bagService.GetEnrouteBagsAsync(destinationGate, since_minutes);
            return Ok(result);
        }

        [HttpGet("stats/gate-counts")]
        public async Task<IActionResult> GetGateRankings([FromQuery] int since_minutes = 60)
        {
            var result = await _bagService.GetGateRankingsAsync(since_minutes);
            return Ok(result);
        }
    }
}
