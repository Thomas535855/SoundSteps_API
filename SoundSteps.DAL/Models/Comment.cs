using System;
using System.Collections.Generic;

namespace SoundSteps.DAL.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? ExerciseId { get; set; }

    public string? Content { get; set; }

    public virtual Exercise? Exercise { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
