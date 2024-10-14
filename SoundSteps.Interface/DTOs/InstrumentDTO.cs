using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.DAL.Models
{
    public class InstrumentDTO
    {
        [Key]
        public int InstrumentId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ExerciseDTO> Exercises { get; set; } = new List<ExerciseDTO>();
        public virtual ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
