using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCompiler.Data.DBModels
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid ResourceId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PointsFromQuestions { get; set; }
        public List<CompletedTask> CompletedTasks { get; set; }

        public User(string username, string password, List<CompletedTask> completedTasks)
        { 
            this.ResourceId = Guid.NewGuid();
            this.Username = username;
            this.Password = password;
            this.CompletedTasks = completedTasks;
            this.PointsFromQuestions = 0;
        }

        public User(string username, string password)
        {
            this.ResourceId = Guid.NewGuid();
            this.Username = username;
            this.Password = password;
            this.CompletedTasks = new List<CompletedTask>();
            this.PointsFromQuestions = 0;
        }

        public User()
        {
        }
    }
}
