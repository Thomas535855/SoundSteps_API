using System.ComponentModel.DataAnnotations;

namespace SoundSteps.DAL.Models
{
    public class InstrumentDto
    {
        [Key]
        public int InstrumentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExerciseDto> Exercises { get; set; } = new List<ExerciseDto>();
        public virtual ICollection<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
