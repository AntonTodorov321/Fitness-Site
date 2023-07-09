namespace FitnessSite.Data.Configutarion
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasData(GenerateExercises());
        }

        private Exercise[] GenerateExercises()
        {
            List<Exercise> exercises = new List<Exercise>()
            {
                 new Exercise()
                 {
                      Id = 1,
                      Name = "Push-Ups",
                       Description =
                       "An exercise in which a person, keeping a prone position with the handspalms down under the shoulders",
                        TypeId = 1,
                        Sets = 4,
                        Reps = 10,
                        ImageUrl = "https://blog.nasm.org/hubfs/power-pushups.jpg"
                 }
            };

            return exercises.ToArray();
        }
    }
}
