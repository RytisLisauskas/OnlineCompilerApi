using JDoodleHttpClient;
using JDoodleHttpClient.Models;
using OnlineCompiler.Models;

namespace OnlineCompiler.Services
{
    public class CompilatingService : ICompilatingService
    {
        private IJDoodleClient jDoodleClient;

        public CompilatingService(IJDoodleClient jDoodleClient)
        {
            this.jDoodleClient = jDoodleClient;
        }


        public async Task<CompilationResultResponse> CompileCode(CompilationRequestContract request)
        {
            var requestModel = new JDoodleRequestModel(request.Script, request.Language, request.VersionIndex);
            var response = await jDoodleClient.ExecuteTask(requestModel);
            return new CompilationResultResponse(response);
        }
    }
}
