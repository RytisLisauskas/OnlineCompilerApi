using OnlineCompiler.Data.DBModels;
using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Data.Repositories
{
    public class CompilerRepo : ICompilerRepo
    {
        OnlineCompilerDbContext Context { get; set; }

        public CompilerRepo()
        { 
            Context = new OnlineCompilerDbContext();
        }
        public bool AddTask(AppTaskDTO task)
        {
            Context.AppTasks.Add(new AppTask(task.Description, task.AvailablePoints, task.Name, task.Answer));
            Context.SaveChanges();
            return true;
        }

        public List<AppTaskDTO> GetAllTasks()
        {
            var tasks = Context.AppTasks.ToList();
            var dtos = tasks.Select(x => new AppTaskDTO(x)).ToList();
            return dtos;
        }
    }
}
