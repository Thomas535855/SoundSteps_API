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


        public Instrument(InstrumentDto dto)
        {
            InstrumentId = dto.InstrumentId;
            Name = dto.Name;
            Exercises = dto.Exercises.Select(e => new Exercise(e)).ToList();
        }

        public InstrumentDto ToDto()
        {
            return new InstrumentDto
            {
                InstrumentId = InstrumentId, 
                Name = Name, 
                Exercises = Exercises.Select(e => e.ToDto()).ToList(),
            };
        }
    }
}
