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
                       ExerciseId = Guid.Parse("2d41e21a-e8c8-4c7a-8690-3a846772b6b6"),
                       MuscleId = 7
                 },

                 new MuscleExercise()
                 {
                     ExerciseId = Guid.Parse("23f41c9e-da15-4282-b5cc-1cbadb6ca92e"),
                     MuscleId = 2
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("8cb1af1b-b63a-458b-adfa-dc077a02c4f9"),
                    MuscleId = 6
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("88922675-b7df-4a4a-9313-231d2c13a3a2"),
                    MuscleId = 7
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("88922675-b7df-4a4a-9313-231d2c13a3a2"),
                    MuscleId = 3
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("2d41e21a-e8c8-4c7a-8690-3a846772b6b6"),
                    MuscleId = 1
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("2d41e21a-e8c8-4c7a-8690-3a846772b6b6"),
                    MuscleId = 2
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("23f41c9e-da15-4282-b5cc-1cbadb6ca92e"),
                    MuscleId = 5
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("a22ab0dd-3e6a-444f-b21d-b7f69707bb28"),
                    MuscleId = 4
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("6587e2a8-e9f1-4fd9-bd7e-503078be010b"),
                    MuscleId = 2
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("8cb1af1b-b63a-458b-adfa-dc077a02c4f9"),
                    MuscleId = 4
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("88922675-b7df-4a4a-9313-231d2c13a3a2"),
                    MuscleId = 6
                 }
            };

            return muscleExercises.ToArray();
        }
    }
}
