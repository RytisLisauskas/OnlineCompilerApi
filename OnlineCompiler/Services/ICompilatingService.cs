using OnlineCompiler.Models;

namespace OnlineCompiler.Services
{
    public interface ICompilatingService
    {
        public Task<CompilationResultResponse> CompileCode(CompilationRequestContract request);
    }
}
