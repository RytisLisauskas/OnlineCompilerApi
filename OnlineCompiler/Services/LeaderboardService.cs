using OnlineCompiler.Models;

namespace OnlineCompiler.Services
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly IUserService _userService;

        public LeaderboardService(IUserService service)
        { 
            _userService = service;
        }
        public List<LeaderboardEntry> GetLeaderBoard()
        {
            var users = _userService.GetAllUsers();
            List<LeaderboardEntry> entries = new List<LeaderboardEntry>();
            foreach (var user in users)
            {
                var completedTasksPoints = user.CompletedTasks!.Select(task => task.PointsEarned).Sum();
                var completedTasksNames = user.CompletedTasks!.Select(task => task.Name).ToList();
                var pointsFromQuestions = user.PointsFromQuestions;
                entries.Add(new LeaderboardEntry(user.Username!, completedTasksPoints, completedTasksNames!, pointsFromQuestions));
            }
            entries.Sort((e1, e2) => e1.Points.CompareTo(e2.Points));
            entries.Reverse();
            return entries;
        }
    }
}
