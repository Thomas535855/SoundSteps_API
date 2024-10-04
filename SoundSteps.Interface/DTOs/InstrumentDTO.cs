using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.DAL.Models
{
    public class InstrumentDTO
    {
        public int InstrumentId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ExerciseDTO>? Exercises { get; set; }
        public virtual ICollection<UserDTO>? Users { get; set; }
    }
}
