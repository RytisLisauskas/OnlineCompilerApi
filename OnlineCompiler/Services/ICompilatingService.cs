using OnlineCompiler.Models;
using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Services
{
    public interface ICompilatingService
    {
        public Task<CompilationResultResponse> CompileCode(CompilationRequestContract request);
        public bool AddTask(AddTaskRequestContract body);
        public List<AppTaskDTO> GetAllTasks();
    }
}
