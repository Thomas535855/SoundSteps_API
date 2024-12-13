using Microsoft.EntityFrameworkCore;
using SoundSteps.DAL.Models;

namespace SoundSteps.DAL;

public partial class SoundStepsDbContext(DbContextOptions<SoundStepsDbContext> options) : DbContext(options)
{

    public virtual DbSet<ExerciseDto> Exercises { get; set; }

    public virtual DbSet<InstrumentDto> Instruments { get; set; }

    public virtual DbSet<UserDto> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();
    
}
