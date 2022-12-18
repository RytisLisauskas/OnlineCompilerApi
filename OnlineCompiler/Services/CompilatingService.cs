using JDoodleHttpClient;
using JDoodleHttpClient.Models;
using OnlineCompiler.Data.Repositories;
using OnlineCompiler.Helpers;
using OnlineCompiler.Models;
using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Services
{
    public class CompilatingService : ICompilatingService
    {
        private IJDoodleClient jDoodleClient;
        private ICompilerRepo compilerRepo;
        private IUserService _userService;
        private IQuestionService _questionService;
        public CompilatingService(IJDoodleClient jDoodleClient, ICompilerRepo compilerRepo, IUserService userService, IQuestionService questionService)
        {
            this.jDoodleClient = jDoodleClient;
            this.compilerRepo = compilerRepo;
            this._userService = userService;
            this._questionService = questionService;

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

        public AppTaskDTO GetById(Guid id)
        { 
            return compilerRepo.GetTaskById(id);
        }

        public List<AppTaskDTO> GetAllTasks()
        { 
            return compilerRepo.GetAllTasks();
        }

        public bool DeleteTask(Guid id)
        {
            return compilerRepo.DeleteTask(id);
        }

        public async Task<bool> CheckSolution(Guid taskId, Guid userId, CompilationRequestContract request)
        {
            var response = await CompileCode(request);
            var task  = GetById(taskId);
            if (task.Answer == response.Result.RemoveWhiteSpaces())
            {
                _userService.AddCompletedTask(userId, task);
                return true;
            }
            return false;
        }

        public bool CheckAnswer(Guid QuestionId, Guid UserId, string answer)
        { 
            var question = _questionService.GetQuestionById(QuestionId);
            if (question == null)
            {
                return false;
            }
            var user = _userService.GetById(UserId);
            if (user == null)
            {
                return false;
            }
            if (answer.RemoveWhiteSpaces().Equals(question.CorrectAnswer!.RemoveWhiteSpaces()))
            {
                return _userService.AddAnswerPoints(UserId, question.AvailablePoints);
            }
            return false;

        }
    }
}
