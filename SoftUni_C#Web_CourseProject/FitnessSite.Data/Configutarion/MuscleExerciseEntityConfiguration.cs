namespace FitnessSite.Data.Configutarion
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class MuscleExerciseEntityConfiguration : IEntityTypeConfiguration<MuscleExercise>
    {
        public void Configure(EntityTypeBuilder<MuscleExercise> builder)
        {
            builder.HasData(GenerateMuscleExercise());
        }

        private MuscleExercise[] GenerateMuscleExercise()
        {
            List<MuscleExercise> muscleExercises = new List<MuscleExercise>()
            {
                 new MuscleExercise()
                 {
                       ExerciseId = 1,
                       MuscleId = 7
                 },
                 new MuscleExercise()
                 {
                     ExerciseId = 1,
                     MuscleId = 2
                 }
            };

            return muscleExercises.ToArray();
        }
    }
}
