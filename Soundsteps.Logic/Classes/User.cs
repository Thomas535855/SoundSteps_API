using SoundSteps.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        public ICollection<Instrument> Instruments { get; set; } = new List<Instrument>();

        public ICollection<Exercise> Exercises { get; set; }

        public User(UserDto dto)
        {
            UserId = dto.UserId;
            Username = dto.Username;
            Email = dto.Email;
            Password = dto.Password;
            SkillLevel = dto.SkillLevel;
            Instruments = dto.Instruments.Select(i => new Instrument(i)).ToList(); ;
            Exercises = dto.Exercises.Select(e => new Exercise(e)).ToList(); ;
        }

        public UserDto ToDto()
        {
            return new UserDto
            {
                UserId = UserId,
                Username = Username,
                Email = Email,
                Password = Password,
                SkillLevel = SkillLevel,
                Instruments = Instruments.Select(i => i.ToDto()).ToList(),
                Exercises = Exercises.Select(e => e.ToDto()).ToList(),
            };
        }
    }
}
