using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Services
{
    public interface IQuestionService
    {
        public bool AddQuestion(QuestionDTO question);
        public List<QuestionDTO> GetQuestions();

        public bool DeleteQuestion(Guid id);
        public QuestionDTO? GetQuestionById(Guid id);
    }
}
