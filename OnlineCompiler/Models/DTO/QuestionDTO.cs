using OnlineCompiler.Data.DBModels;

namespace OnlineCompiler.Models.DTO
{
    public class QuestionDTO
    {
        public Guid? ResourceId { get; set; }
        public string? QuestionText { get; set; }
        public int AvailablePoints { get; set; }
        public string? CorrectAnswer { get; set; }
        public List<AnswerDTO>? Answers { get; set; }

        public QuestionDTO()
        { }
    }
}
