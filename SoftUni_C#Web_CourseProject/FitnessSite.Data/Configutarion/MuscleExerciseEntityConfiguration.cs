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
                       ExerciseId = Guid.Parse("c2bc09b8-3eab-4186-97a3-b6c7ea22abd0"),
                       MuscleId = 5
                 },

                 new MuscleExercise()
                 {
                     ExerciseId = Guid.Parse("aae7f8d7-7c1f-49a4-af67-d994b578c64b"),
                     MuscleId = 2
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("422095ab-bc18-40da-860c-1ede0265847c"),
                    MuscleId = 6
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("5ddfc3ee-0162-445b-a496-eaedd09f5369"),
                    MuscleId = 7
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("422095ab-bc18-40da-860c-1ede0265847c"),
                    MuscleId = 3
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("5ddfc3ee-0162-445b-a496-eaedd09f5369"),
                    MuscleId = 1
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("5ddfc3ee-0162-445b-a496-eaedd09f5369"),
                    MuscleId = 2
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("aae7f8d7-7c1f-49a4-af67-d994b578c64b"),
                    MuscleId = 5
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("61f17628-8461-48aa-b20f-f71fc53fa4bd"),
                    MuscleId = 4
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("c2bc09b8-3eab-4186-97a3-b6c7ea22abd0"),
                    MuscleId = 2
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("0537415a-8a0b-40fa-a546-f9f9299d781f"),
                    MuscleId = 4
                 },

                 new MuscleExercise()
                 {
                    ExerciseId = Guid.Parse("0537415a-8a0b-40fa-a546-f9f9299d781f"),
                    MuscleId = 6
                 }
            };

            return muscleExercises.ToArray();
        }
    }
}
