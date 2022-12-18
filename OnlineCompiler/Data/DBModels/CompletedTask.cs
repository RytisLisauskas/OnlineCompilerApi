using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCompiler.Data.DBModels
{
    public class CompletedTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid? ResourceId { get; set; }
        public string? Name { get; set; }
        public int PointsEarned { get; set; }
        public User? User { get; set; }

        public CompletedTask(string Name, int PointsEarned)
        { 
            this.Name = Name;
            this.PointsEarned = PointsEarned;
            this.ResourceId = Guid.NewGuid();
        }

        public CompletedTask()
        {
        }
    }
}
