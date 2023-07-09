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
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = 2,
                    MuscleId = 6
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = 2,
                    MuscleId = 7
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = 2,
                    MuscleId = 3
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = 3,
                    MuscleId = 1
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = 3,
                    MuscleId = 2
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = 3,
                    MuscleId = 5
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = 4,
                    MuscleId = 4
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = 5,
                    MuscleId = 2
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = 5,
                    MuscleId = 5
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = 6,
                    MuscleId = 4
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = 6,
                    MuscleId = 6
                 }
            };

            return muscleExercises.ToArray();
        }
    }
}
