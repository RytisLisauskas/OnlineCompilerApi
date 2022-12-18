namespace OnlineCompiler.Models
{
    public class LeaderboardEntry
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int PointsFromQuestions { get; set; }
        public List<string> CompletedTasks { get; set; }

        public LeaderboardEntry(string name, int points, List<string> completedTasks, int pointsFromQuestions)
        { 
            this.Name = name;
            Points = points + pointsFromQuestions;
            CompletedTasks = completedTasks;
            PointsFromQuestions = pointsFromQuestions;
        }
    }
}
