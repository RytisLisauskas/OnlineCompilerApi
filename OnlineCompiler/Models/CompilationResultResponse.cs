using JDoodleHttpClient.Models;

namespace OnlineCompiler.Models
{
    public class CompilationResultResponse
    {
        public string Result { get; set; }
        public string CpuUsed { get; set; }
        public string MemoryUsed { get; set; }

        public CompilationResultResponse(JDoodleResponseModel responseModel)
        {
            Result = responseModel.Output;
            CpuUsed = responseModel.CpuTime;
            MemoryUsed = responseModel.Memory;
        }

    }
}
