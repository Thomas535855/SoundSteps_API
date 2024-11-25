using SoundSteps.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace SoundSteps.Logic.Classes
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? SkillLevel { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Instrument> Instruments { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

        public User(UserDTO dto)
        {
            UserId = dto.UserId;
            Username = dto.Username;
            Email = dto.Email;
            Password = dto.Password;
            SkillLevel = dto.SkillLevel;
            Comments = dto.Comments.Select(c => new Comment(c)).ToList(); ;
            Instruments = dto.Instruments.Select(i => new Instrument(i)).ToList(); ;
            Exercises = dto.Exercises.Select(e => new Exercise(e)).ToList(); ;
        }

        public UserDTO ToDTO()
        {
            return new UserDTO
            {
                UserId = UserId,
                Username = Username,
                Email = Email,
                Password = Password,
                SkillLevel = SkillLevel,
                Comments = Comments.Select(c => c.ToDTO()).ToList(),
                Instruments = Instruments.Select(i => i.ToDTO()).ToList(),
                Exercises = Exercises.Select(e => e.ToDTO()).ToList(),
            };
        }
    }
}
