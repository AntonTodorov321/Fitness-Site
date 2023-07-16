//namespace FitnessSite.Data.Configutarion
//{
//    using System.Collections.Generic;

//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;

//    using Models;

//    internal class MuscleExerciseEntityConfiguration : IEntityTypeConfiguration<MuscleExercise>
//    {
//        public void Configure(EntityTypeBuilder<MuscleExercise> builder)
//        {
//            builder.HasData(GenerateMuscleExercise());
//        }

//        private MuscleExercise[] GenerateMuscleExercise()
//        {
//            List<MuscleExercise> muscleExercises = new List<MuscleExercise>()
//            {
//                 new MuscleExercise()
//                 {
//                       ExerciseId = Guid.NewGuid(),
//                       MuscleId = 7
//                 },

//                 new MuscleExercise()
//                 {
//                     ExerciseId = Guid.NewGuid(),
//                     MuscleId = 2
//                 },

//                 new MuscleExercise()
//                 {
//                    ExerciseId = Guid.NewGuid(),
//                    MuscleId = 6
//                 },

//                 new MuscleExercise()
//                 {
//                    ExerciseId = Guid.NewGuid(),
//                    MuscleId = 7
//                 },

//                 new MuscleExercise()
//                 {
//                    ExerciseId = Guid.NewGuid(),
//                    MuscleId = 3
//                 },

//                 new MuscleExercise()
//                 {
//                    ExerciseId = Guid.NewGuid(),
//                    MuscleId = 1
//                 },

//                 new MuscleExercise()
//                 {
//                    ExerciseId = Guid.NewGuid(),
//                    MuscleId = 2
//                 },

//                 new MuscleExercise()
//                 {
//                    ExerciseId = Guid.NewGuid(),
//                    MuscleId = 5
//                 },

//                 new MuscleExercise()
//                 {
//                    ExerciseId = Guid.NewGuid(),
//                    MuscleId = 4
//                 },

//                 new MuscleExercise()
//                 {
//                    ExerciseId = Guid.NewGuid(),
//                    MuscleId = 2
//                 },

//                 new MuscleExercise()
//                 {
//                    ExerciseId = Guid.NewGuid(),
//                    MuscleId = 5
//                 },

//                 new MuscleExercise()
//                 {
//                    ExerciseId = Guid.NewGuid(),
//                    MuscleId = 4
//                 },

//                 new MuscleExercise()
//                 {
//                    ExerciseId = Guid.NewGuid(),
//                    MuscleId = 6
//                 }
//            };

//            return muscleExercises.ToArray();
//        }
//    }
//}
