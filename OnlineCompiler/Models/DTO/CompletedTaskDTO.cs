using OnlineCompiler.Data.DBModels;

namespace OnlineCompiler.Models.DTO
{
    public class CompletedTaskDTO
    {
        public Guid? ResourceId { get; set; }
        public string? Name { get; set; }
        public int PointsEarned { get; set; }

        public CompletedTaskDTO(CompletedTask completedTask)
        { 
            this.ResourceId = completedTask.ResourceId;
            this.Name = completedTask.Name;
            this.PointsEarned = completedTask.PointsEarned;
        }
        public CompletedTaskDTO()
        {
        }

        public CompletedTaskDTO(AppTaskDTO completedTask)
        {
            this.ResourceId = Guid.NewGuid();
            this.Name = completedTask.Name;
            this.PointsEarned = completedTask.AvailablePoints;
        }
    }
}
