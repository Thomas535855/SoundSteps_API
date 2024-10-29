﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoundSteps.DAL;

#nullable disable

namespace SoundSteps.DAL.Migrations
{
    [DbContext(typeof(SoundStepsDbContext))]
    partial class SoundStepsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExerciseDTOUserDTO", b =>
                {
                    b.Property<int>("ExercisesExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("ExercisesExerciseId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("ExerciseDTOUserDTO");
                });

            modelBuilder.Entity("InstrumentDTOUserDTO", b =>
                {
                    b.Property<int>("InstrumentsInstrumentId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("InstrumentsInstrumentId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("InstrumentDTOUserDTO");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.CommentDTO", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExerciseDTOExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("ExerciseDTOExerciseId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.ExerciseDTO", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseId"));

                    b.Property<int>("InstrumentId")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.HasKey("ExerciseId");

                    b.HasIndex("InstrumentId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.InstrumentDTO", b =>
                {
                    b.Property<int>("InstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstrumentId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrumentId");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.UserDTO", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExerciseDTOUserDTO", b =>
                {
                    b.HasOne("SoundSteps.DAL.Models.ExerciseDTO", null)
                        .WithMany()
                        .HasForeignKey("ExercisesExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoundSteps.DAL.Models.UserDTO", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InstrumentDTOUserDTO", b =>
                {
                    b.HasOne("SoundSteps.DAL.Models.InstrumentDTO", null)
                        .WithMany()
                        .HasForeignKey("InstrumentsInstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoundSteps.DAL.Models.UserDTO", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.CommentDTO", b =>
                {
                    b.HasOne("SoundSteps.DAL.Models.ExerciseDTO", null)
                        .WithMany("Comments")
                        .HasForeignKey("ExerciseDTOExerciseId");

                    b.HasOne("SoundSteps.DAL.Models.UserDTO", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.ExerciseDTO", b =>
                {
                    b.HasOne("SoundSteps.DAL.Models.InstrumentDTO", "Instrument")
                        .WithMany("Exercises")
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instrument");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.ExerciseDTO", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.InstrumentDTO", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.UserDTO", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
