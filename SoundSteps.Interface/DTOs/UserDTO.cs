using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.DAL.Models
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int? SkillLevel { get; set; }

        public ICollection<CommentDTO>? Comments { get; set; }

        public ICollection<InstrumentDTO>? Instruments { get; set; }
        public ICollection<ExerciseDTO>? Exercises { get; set; }
    }
}
