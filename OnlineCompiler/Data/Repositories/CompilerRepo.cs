using AutoMapper;
using OnlineCompiler.Data.DBModels;
using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Data.Repositories
{
    public class CompilerRepo : ICompilerRepo
    {
        OnlineCompilerDbContext Context { get; set; }
        private readonly IMapper _mapper;
        public CompilerRepo(IMapper mapper)
        {
            _mapper = mapper;
            Context = new OnlineCompilerDbContext();
        }
        public bool AddTask(AppTaskDTO task)
        {
            Context.AppTasks.Add(new AppTask(task.Description, task.AvailablePoints, task.Name, task.Answer));
            Context.SaveChanges();
            return true;
        }

        public AppTaskDTO GetTaskById(Guid id)
        {
           return _mapper.Map<AppTask, AppTaskDTO>(Context.AppTasks.First(x => x.ResourceId == id));
        }

        public List<AppTaskDTO> GetAllTasks()
        {
            var tasks = Context.AppTasks.ToList();
            var dtos = tasks.Select(x => new AppTaskDTO(x)).ToList();
            return dtos;
        }

        public bool DeleteTask(Guid id)
        { 
            var task = Context.AppTasks.FirstOrDefault(x => x.ResourceId == id);
            if (task != null)
            { 
                Context.AppTasks.Remove(task);
                Context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
