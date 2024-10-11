using Microsoft.EntityFrameworkCore;
using SoundSteps.DAL.Models;

namespace SoundSteps.DAL;

public partial class SoundStepsDbContext : DbContext
{
    public SoundStepsDbContext(DbContextOptions<SoundStepsDbContext> options)
            : base(options)
    {

    }

    public virtual DbSet<CommentDTO> Comments { get; set; }

    public virtual DbSet<ExerciseDTO> Exercises { get; set; }

    public virtual DbSet<InstrumentDTO> Instruments { get; set; }

    public virtual DbSet<UserDTO> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();
}
