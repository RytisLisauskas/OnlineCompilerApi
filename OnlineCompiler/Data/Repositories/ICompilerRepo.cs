using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Data.Repositories
{
    public interface ICompilerRepo
    {
        public bool AddTask(AppTaskDTO task);
        public List<AppTaskDTO> GetAllTasks();
        public AppTaskDTO GetTaskById(Guid id);
        public bool DeleteTask(Guid id);
    }
}
