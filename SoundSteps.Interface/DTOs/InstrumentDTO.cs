using System.ComponentModel.DataAnnotations;

namespace SoundSteps.DAL.Models
{
    public class InstrumentDTO
    {
        [Key]
        public int InstrumentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExerciseDTO> Exercises { get; set; } = new List<ExerciseDTO>();
        public virtual ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
