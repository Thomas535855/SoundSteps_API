using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.DAL.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }

        public int InstrumentId { get; set; }

        public int SkillLevel { get; set; }

        public int Likes { get; set; } = 0;

        public virtual ICollection<Comment>? Comments { get; set; }

        public virtual Instrument? Instrument { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
