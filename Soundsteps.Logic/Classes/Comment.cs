using SoundSteps.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.Logic.Classes
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ExerciseId { get; set; }
        public string Content { get; set; }

        public virtual ICollection<User>? Users { get; set; }

        public Comment(CommentDTO dto)
        {
            CommentId = dto.CommentId;
            ExerciseId = dto.ExerciseId;
            Content = dto.Content;
            Users = dto.Users.Select(u => new User(u)).ToList();
        }

        public CommentDTO ToDTO()
        {
            return new CommentDTO 
            { 
                CommentId = CommentId, 
                ExerciseId = ExerciseId, 
                Content = Content,
                Users = Users.Select(u =>  u.ToDTO()).ToList(),
            };
    }
}
