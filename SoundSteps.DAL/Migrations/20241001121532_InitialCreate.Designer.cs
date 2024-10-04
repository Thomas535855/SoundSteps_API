﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoundSteps.DAL;

#nullable disable

namespace SoundSteps.DAL.Migrations
{
    [DbContext(typeof(SoundStepsDbContext))]
    [Migration("20241001121532_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SoundSteps.DAL.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("ExerciseId");

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

            modelBuilder.Entity("SoundSteps.DAL.Models.Instrument", b =>
                {
                    b.Property<int>("InstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstrumentId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("InstrumentId");

                    b.HasIndex("UserId");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

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

            modelBuilder.Entity("SoundSteps.DAL.Models.Comment", b =>
                {
                    b.HasOne("SoundSteps.DAL.Models.ExerciseDTO", null)
                        .WithMany("Comments")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoundSteps.DAL.Models.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.ExerciseDTO", b =>
                {
                    b.HasOne("SoundSteps.DAL.Models.Instrument", "Instrument")
                        .WithMany("Exercises")
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instrument");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.Instrument", b =>
                {
                    b.HasOne("SoundSteps.DAL.Models.User", null)
                        .WithMany("Instruments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.ExerciseDTO", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.Instrument", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("SoundSteps.DAL.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Instruments");
                });
#pragma warning restore 612, 618
        }
    }
}
