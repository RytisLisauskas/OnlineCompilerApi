using OnlineCompiler.Models;
using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Services
{
    public interface ICompilatingService
    {
        public Task<CompilationResultResponse> CompileCode(CompilationRequestContract request);
        public bool AddTask(AddTaskRequestContract body);
        public List<AppTaskDTO> GetAllTasks();
        public Task<bool> CheckSolution(Guid taskId, Guid userId, CompilationRequestContract request);
        public bool DeleteTask(Guid id);
        public bool CheckAnswer(Guid QuestionId, Guid UserId, string answer);
    }
}
