using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCompiler.Data.DBModels
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Text { get; set; }
        public Question? Question { get; set; }

        public Answer(string text)
        { 
            Text = text;
        }

        public Answer()
        { }
    }
}
