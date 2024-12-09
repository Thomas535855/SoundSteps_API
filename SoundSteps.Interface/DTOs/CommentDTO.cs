using System.ComponentModel.DataAnnotations;

namespace SoundSteps.DAL.Models
{
    public class CommentDto
    {
        [Key]
        public int CommentId { get; set; }
        public int ExerciseId { get; set; }
        public string Content { get; set; }

        public virtual UserDto User { get; set; } = null!;
    }
}
