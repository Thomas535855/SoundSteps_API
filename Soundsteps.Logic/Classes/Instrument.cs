using SoundSteps.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace SoundSteps.Logic.Classes
{
    public class Instrument
    {
        [Key]
        public int InstrumentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Instrument(InstrumentDTO dto)
        {
            InstrumentId = dto.InstrumentId;
            Name = dto.Name;
            Exercises = dto.Exercises.Select(e => new Exercise(e)).ToList();
            Users = dto.Users.Select(u => new User(u)).ToList();
        }

        public InstrumentDTO ToDTO()
        {
            return new InstrumentDTO
            {
                InstrumentId = InstrumentId, 
                Name = Name, 
                Exercises = Exercises.Select(e => e.ToDTO()).ToList(),
                Users = Users.Select(u => u.ToDTO()).ToList(),
            };
        }
    }
}
