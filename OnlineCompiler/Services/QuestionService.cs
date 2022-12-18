using OnlineCompiler.Data.Repositories;
using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepo _questionRepo;

        public QuestionService(IQuestionRepo service)
        {
            _questionRepo = service;
        }
        public bool AddQuestion(QuestionDTO question)
        {
            return _questionRepo.AddQuestion(question);
        }

        public bool DeleteQuestion(Guid id)
        {
            return _questionRepo.RemoveQuestion(id);
        }

        public QuestionDTO? GetQuestionById(Guid id)
        {
            return _questionRepo.GetQuestion(id);
        }

        public List<QuestionDTO> GetQuestions()
        {
            return _questionRepo.GetAllQuestions();
        }
    }
}
