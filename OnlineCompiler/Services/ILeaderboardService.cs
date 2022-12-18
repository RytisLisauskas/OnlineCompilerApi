using OnlineCompiler.Models;

namespace OnlineCompiler.Services
{
    public interface ILeaderboardService
    {
        public List<LeaderboardEntry> GetLeaderBoard();
    }
}
