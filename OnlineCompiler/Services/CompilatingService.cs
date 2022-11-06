using JDoodleHttpClient;
using JDoodleHttpClient.Models;
using OnlineCompiler.Data.Repositories;
using OnlineCompiler.Models;
using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Services
{
    public class CompilatingService : ICompilatingService
    {
        private IJDoodleClient jDoodleClient;
        private ICompilerRepo compilerRepo;
        public CompilatingService(IJDoodleClient jDoodleClient, ICompilerRepo compilerRepo)
        {
            this.jDoodleClient = jDoodleClient;
            this.compilerRepo = compilerRepo;

         }


        public async Task<CompilationResultResponse> CompileCode(CompilationRequestContract request)
        {
            var requestModel = new JDoodleRequestModel(request.Script, request.Language, request.VersionIndex);
            var response = await jDoodleClient.ExecuteTask(requestModel);
            return new CompilationResultResponse(response);
        }

        public bool AddTask(AddTaskRequestContract body)
        {
            var dto = new AppTaskDTO(body);
            var result = compilerRepo.AddTask(dto);
            return result;
        }

        public List<AppTaskDTO> GetAllTasks()
        { 
            return compilerRepo.GetAllTasks();
        }
    }
}
