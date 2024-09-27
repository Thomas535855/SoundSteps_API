using System;
using System.Collections.Generic;

namespace SoundSteps.DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? SkillLevel { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

    public virtual ICollection<Exercise> ExercisesNavigation { get; set; } = new List<Exercise>();

    public virtual ICollection<Instrument> Instruments { get; set; } = new List<Instrument>();
}
