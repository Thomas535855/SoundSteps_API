using Microsoft.EntityFrameworkCore;
using SoundSteps.DAL.Models;

namespace SoundSteps.DAL;

public partial class SoundStepsDbContext : DbContext
{
    public SoundStepsDbContext(DbContextOptions<SoundStepsDbContext> options)
            : base(options)
    {

    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<User> Users { get; set; }

}
