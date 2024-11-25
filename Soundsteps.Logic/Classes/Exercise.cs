using SoundSteps.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace SoundSteps.Logic.Classes
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        public int InstrumentId { get; set; }
        public int SkillLevel { get; set; }
        public int Likes { get; set; } = 0;

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Instrument Instrument { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Exercise(ExerciseDTO dto)
        {
            ExerciseId = dto.ExerciseId;
            InstrumentId = dto.InstrumentId;
            SkillLevel = dto.SkillLevel;
            Likes = dto.Likes;
            Comments = dto.Comments.Select(c => new Comment(c)).ToList();
            Instrument = new Instrument(dto.Instrument);
            Users = dto.Users.Select(u => new User(u)).ToList(); ;
        }

        public ExerciseDTO ToDTO()
        {
            return new ExerciseDTO
            {
                ExerciseId = ExerciseId,
                InstrumentId = InstrumentId,
                SkillLevel = SkillLevel,
                Likes = Likes,
                Comments = Comments.Select(c => c.ToDTO()).ToList(),
                Instrument = Instrument.ToDTO(),
                Users = Users.Select(u => u.ToDTO()).ToList(),
            };
        }
    }
}
