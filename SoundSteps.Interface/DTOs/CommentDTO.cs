using System.ComponentModel.DataAnnotations;

namespace SoundSteps.DAL.Models
{
    public class CommentDTO
    {
        [Key]
        public int CommentId { get; set; }
        public int ExerciseId { get; set; }
        public string Content { get; set; }

        public virtual UserDTO User { get; set; } = null!;
    }
}
