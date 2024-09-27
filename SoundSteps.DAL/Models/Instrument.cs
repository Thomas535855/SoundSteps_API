using System;
using System.Collections.Generic;

namespace SoundSteps.DAL.Models;

public partial class Instrument
{
    public int InstrumentId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
