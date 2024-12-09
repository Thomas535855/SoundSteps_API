using SoundSteps.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace SoundSteps.Logic.Classes
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int ExerciseId { get; set; }
        public string Content { get; set; }

        public virtual User User { get; set; }

        public Comment(CommentDto dto)
        {
            CommentId = dto.CommentId;
            ExerciseId = dto.ExerciseId;
            Content = dto.Content;
            User = new User(dto.User);
        }

        public CommentDto ToDto()
        {
            return new CommentDto
            {
                CommentId = CommentId,
                ExerciseId = ExerciseId,
                Content = Content,
                User = User.ToDto(),
            };
        }
    }
}
