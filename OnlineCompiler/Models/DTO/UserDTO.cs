namespace OnlineCompiler.Models.DTO
{
    public class UserDTO
    {
        public Guid? ResourceId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int PointsFromQuestions { get; set; }
        public List<CompletedTaskDTO>? CompletedTasks { get; set; }

        public UserDTO(UserDTO user)
        { 
            ResourceId = user.ResourceId; 
            Username = user.Username;
            Password = user.Password;
            CompletedTasks = user.CompletedTasks;
            PointsFromQuestions = user.PointsFromQuestions;
        }

        public UserDTO()
        {
        }
    }
}
