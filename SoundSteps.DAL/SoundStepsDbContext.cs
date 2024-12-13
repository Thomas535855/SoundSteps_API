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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDto>()
            .HasMany(u => u.Instruments)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "InstrumentUser",
                j => j.HasOne<InstrumentDto>().WithMany().HasForeignKey("InstrumentId"),
                j => j.HasOne<UserDto>().WithMany().HasForeignKey("UserId"));
    }
}

