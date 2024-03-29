﻿namespace FitnessSite.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using FitnessSite.Data.Models;
    using System.Reflection;

    public class FitnessSiteDbContext 
        : IdentityDbContext<ApplicationUser,IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;
        public FitnessSiteDbContext(DbContextOptions<FitnessSiteDbContext> options,
                                    bool seedDb = true)
        : base(options)
        {
            if (!Database.IsRelational())
            {
                Database.EnsureCreated();
            }
            this.seedDb = seedDb;
        }

        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<Training> Trainings { get; set; } = null!;
        public DbSet<TypeExercise> TypeExercises { get; set; } = null!;
        public DbSet<Trainer> Trainers { get; set; } = null!;
        public DbSet<TrainingExercise>? TrainingExercises { get; set; }
        public DbSet<Muscle> Muscles { get; set; } = null!;
        public DbSet<MuscleExercise> MuscleExercises { get; set; } = null!;
        public DbSet<Message>? Messages { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MuscleExercise>()
                .HasKey(me => new { me.ExerciseId, me.MuscleId });

            builder.Entity<TrainingExercise>(e =>
            {
                e.HasKey(te => new { te.TrainingId, te.ExerciseId });

                e.HasOne(te => te.Training)
                .WithMany(te => te.TrainingExercises)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(te => te.Exercise)
                .WithMany(te => te.TrainingExercises)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Trainer>(e =>
            {
                e.HasMany(t => t.ApllicationUsers)
                .WithOne(au => au.Trainer);
            });

            Assembly assembly = Assembly.GetAssembly(typeof(FitnessSiteDbContext))
                ?? Assembly.GetExecutingAssembly();

            if (seedDb)
            {
                builder.ApplyConfigurationsFromAssembly(assembly);
            }

            base.OnModelCreating(builder);
        }
    }
}