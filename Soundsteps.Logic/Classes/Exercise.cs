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

        public virtual Instrument Instrument { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Exercise(ExerciseDto dto)
        {
            ExerciseId = dto.ExerciseId;
            InstrumentId = dto.InstrumentId;
            SkillLevel = dto.SkillLevel;
            Likes = dto.Likes;
            Instrument = new Instrument(dto.Instrument);
        }

        public ExerciseDto ToDto()
        {
            return new ExerciseDto
            {
                ExerciseId = ExerciseId,
                InstrumentId = InstrumentId,
                SkillLevel = SkillLevel,
                Likes = Likes,
                Instrument = Instrument.ToDto(),
                Users = Users.Select(u => u.ToDto()).ToList(),
            };
        }
    }
}
