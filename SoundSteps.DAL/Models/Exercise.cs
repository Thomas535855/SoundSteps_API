using System;
using System.Collections.Generic;

namespace SoundSteps.DAL.Models;

public partial class Exercise
{
    public int ExerciseId { get; set; }

    public int? InstrumentId { get; set; }

    public int? SkillLevel { get; set; }

    public int? Likes { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Instrument? Instrument { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<User> UsersNavigation { get; set; } = new List<User>();
}
