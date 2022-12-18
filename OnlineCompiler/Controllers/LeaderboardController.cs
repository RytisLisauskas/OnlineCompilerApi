using Microsoft.AspNetCore.Mvc;
using OnlineCompiler.Models;
using OnlineCompiler.Services;

namespace OnlineCompiler.Controllers
{   [ApiController]
    [Route("/leaderboard")]
    public class LeaderboardController : Controller
    {
        private readonly ILeaderboardService _leaderboardService;

        public LeaderboardController(ILeaderboardService service)
        {
            _leaderboardService = service;
        }

        [HttpGet]
        public IActionResult GetLeaderboard()
        {
            return Ok(_leaderboardService.GetLeaderBoard());
        }
    }
}
