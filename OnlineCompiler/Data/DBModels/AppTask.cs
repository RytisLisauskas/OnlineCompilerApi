using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCompiler.Data.DBModels
{
    public class AppTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid ResourceId { get; set; }
        public string Description { get; set; }
        public int AvailablePoints { get; set; }
        public string Name { get; set; }
        public string Answer { get; set; }

        public AppTask (string description, int availablePoints, string name, string answer)
        {
            Description = description;
            AvailablePoints = availablePoints;
            Name = name;
            ResourceId = Guid.NewGuid();
            Answer = answer;
        }
    }
}
