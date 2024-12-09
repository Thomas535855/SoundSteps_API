using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.DAL.Models
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? SkillLevel { get; set; }

        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();

        public ICollection<InstrumentDto> Instruments { get; set; } = new List<InstrumentDto>();
        public ICollection<ExerciseDto> Exercises { get; set; } = new List<ExerciseDto>();
    }
}
