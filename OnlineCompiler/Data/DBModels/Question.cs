using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCompiler.Data.DBModels
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid? ResourceId { get; set; }
        public string? QuestionText { get; set; }
        public int AvailablePoints { get; set; }
        public string? CorrectAnswer { get; set; }
        public List<Answer>? Answers { get; set; }

        public Question(int id, string questionText, int availablePoints, string correctAnswer, List<Answer> answers)
        { 
            this.Id = id;
            this.QuestionText = questionText;
            this.AvailablePoints = availablePoints;
            this.CorrectAnswer = correctAnswer;
            this.Answers = answers;
            this.ResourceId = Guid.NewGuid();
        }

        public Question()
        { }
    }
}
