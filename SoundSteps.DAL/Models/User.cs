using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.DAL.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int? SkillLevel { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public ICollection<Instrument>? Instruments { get; set; }
        public ICollection<Exercise>? Exercises { get; set; }
    }
}
