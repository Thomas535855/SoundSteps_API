using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoundSteps.DAL.Models;

namespace SoundSteps.DAL;

public partial class SoundStepsDbContext : DbContext
{
    public SoundStepsDbContext()
    {

    }

    public SoundStepsDbContext(DbContextOptions<SoundStepsDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFCAD8CDB121");

            entity.Property(e => e.Content).HasMaxLength(255);

            entity.HasOne(d => d.Exercise).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ExerciseId)
                .HasConstraintName("FK__Comments__Exerci__37A5467C");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("PK__Exercise__A074AD2F1341B32A");

            entity.Property(e => e.Likes).HasDefaultValue(0);
            entity.Property(e => e.SkillLevel).HasColumnName("Skill_Level");

            entity.HasOne(d => d.Instrument).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.InstrumentId)
                .HasConstraintName("FK__Exercises__Instr__29572725");

            entity.HasMany(d => d.UsersNavigation).WithMany(p => p.ExercisesNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "FavoriteExercise",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Favorite___UserI__2D27B809"),
                    l => l.HasOne<Exercise>().WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Favorite___Exerc__2C3393D0"),
                    j =>
                    {
                        j.HasKey("ExerciseId", "UserId").HasName("PK__Favorite__710C21EB96B2BDF8");
                        j.ToTable("Favorite_Exercise");
                    });
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK__Instrume__430A5386B8E69A0F");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CB19F4FAC");

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.SkillLevel).HasColumnName("Skill_Level");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasMany(d => d.Comments).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "CommentLike",
                    r => r.HasOne<Comment>().WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CommentLi__Comme__3B75D760"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CommentLi__UserI__3A81B327"),
                    j =>
                    {
                        j.HasKey("UserId", "CommentId").HasName("PK__CommentL__ABB381B05E8C0E41");
                        j.ToTable("Comment_Like");
                    });

            entity.HasMany(d => d.Exercises).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "ExerciseLike",
                    r => r.HasOne<Exercise>().WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ExerciseL__Exerc__30F848ED"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ExerciseL__UserI__300424B4"),
                    j =>
                    {
                        j.HasKey("UserId", "ExerciseId").HasName("PK__Exercise__FD8F869EC080248E");
                        j.ToTable("Exercise_Like");
                    });

            entity.HasMany(d => d.Instruments).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserInstrument",
                    r => r.HasOne<Instrument>().WithMany()
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserInstr__Instr__34C8D9D1"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserInstr__UserI__33D4B598"),
                    j =>
                    {
                        j.HasKey("UserId", "InstrumentId").HasName("PK__UserInst__63B869744C386A01");
                        j.ToTable("User_Instrument");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
