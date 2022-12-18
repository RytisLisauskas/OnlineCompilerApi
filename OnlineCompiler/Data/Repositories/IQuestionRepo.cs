using OnlineCompiler.Models.DTO;

namespace OnlineCompiler.Data.Repositories
{
    public interface IQuestionRepo
    {
        public bool AddQuestion(QuestionDTO question);
        public List<QuestionDTO> GetAllQuestions();
        public bool RemoveQuestion(Guid id);
        public QuestionDTO? GetQuestion(Guid id);
    }
}
