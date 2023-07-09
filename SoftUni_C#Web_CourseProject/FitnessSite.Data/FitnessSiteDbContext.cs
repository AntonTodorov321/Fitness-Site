namespace FitnessSite.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using FitnessSite.Data.Models;
    using System.Reflection;

    public class FitnessSiteDbContext 
        : IdentityDbContext<ApplicationUser,IdentityRole<Guid>, Guid>
    {
        public FitnessSiteDbContext(DbContextOptions<FitnessSiteDbContext> options)
        : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<Training> Trainings { get; set; } = null!;
        public DbSet<TypeExercise> TypeExercises { get; set; } = null!;
        public DbSet<Trainer> Trainers { get; set; } = null!;
        public DbSet<Muscle> Muscles { get; set; } = null!;

        public DbSet<TrainingExercise> TrainingExercises = null!;

        public DbSet<MuscleExercise> MuscleExercises { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MuscleExercise>()
                .HasKey(me => new { me.ExerciseId, me.MuscleId});

            builder.Entity<TrainingExercise>()
                .HasKey(te => new { te.TrainingId, te.ExerciseId });

            Assembly assembly = Assembly.GetAssembly(typeof(FitnessSiteDbContext))
                ?? Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(builder);
        }
    }
}