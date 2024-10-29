using SoundSteps.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundSteps.Logic.Classes
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int ExerciseId { get; set; }
        public string Content { get; set; }

        public virtual User User { get; set; }

        public Comment(CommentDTO dto)
        {
            CommentId = dto.CommentId;
            ExerciseId = dto.ExerciseId;
            Content = dto.Content;
            User = new User(dto.User);
        }

        public CommentDTO ToDTO()
        {
            return new CommentDTO
            {
                CommentId = CommentId,
                ExerciseId = ExerciseId,
                Content = Content,
                User = User.ToDTO(),
            };
        }
    }
}
