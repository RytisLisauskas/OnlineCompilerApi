using OnlineCompiler.Data.DBModels;

namespace OnlineCompiler.Models.DTO
{
    public class AppTaskDTO
    {
        public Guid ResourceID { get; set; }
        public string Description { get; set; }
        public int AvailablePoints { get; set; }
        public string Name { get; set; }
        public string Answer { get; set; }

        public AppTaskDTO(AppTask task)
        {
            ResourceID = task.ResourceId;
            Description = task.Description;
            AvailablePoints = task.AvailablePoints;
            Name = task.Name;
            Answer = task.Answer;
        }
        public AppTaskDTO(AddTaskRequestContract contract)
        {
            Description = contract.Description;
            AvailablePoints = contract.AvailablePoints;
            Name = contract.Name;
            Answer = contract.Answer;
        }
    }
}
