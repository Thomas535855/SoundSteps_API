using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.DAL.Models
{
    public class ExerciseDto
    {
        [Key]
        public int ExerciseId { get; set; }
        public int InstrumentId { get; set; }
        public int SkillLevel { get; set; }
        public int Likes { get; set; } = 0;

        public virtual ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();

        public virtual InstrumentDto Instrument { get; set; } = null!;
        public virtual ICollection<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
