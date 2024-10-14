using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.DAL.Models
{
    public class UserDTO
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int? SkillLevel { get; set; }

        public ICollection<CommentDTO> Comments { get; set; } = new List<CommentDTO>();

        public ICollection<InstrumentDTO> Instruments { get; set; } = new List<InstrumentDTO>();
        public ICollection<ExerciseDTO> Exercises { get; set; } = new List<ExerciseDTO>();
    }
}
