namespace SoundSteps.DAL.Models
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public int ExerciseId { get; set; }
        public string Content { get; set; }

        public virtual ICollection<UserDTO>? Users { get; set; }
    }
}
