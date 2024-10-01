using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.DAL.Models
{
    public class Instrument
    {
        public int InstrumentId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Exercise>? Exercises { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
