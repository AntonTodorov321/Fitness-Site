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
                      "An exercise in which a person, keeping a prone position with thehandspalms down under the shoulders",
                       TypeId = 1,
                       Sets = "4",
                       Reps = "10",
                       ImageUrl = "https://blog.nasm.org/hubfs/power-pushups.jpg"
                 },

                  new Exercise()
                 {
                      Id = 2,
                      Name = "Plank",
                      Description =
                      "Start in a tabletop position on your hands and knees, then lower down toyour forearms with your elbows stacked beneath your shoulders. Step yo  feet back until your body makes a line from shoulders to heels.",
                       TypeId = 1,
                       Sets = "3",
                       Reps = "8",
                       ImageUrl = "https://blog-images-1.pharmeasy.in/blog/production/wp-content/uploads/2021/01/06152556/3.jpg"
                 },

                   new Exercise()
                 {
                      Id = 3,
                      Name = "Pull-Ups",
                      Description =
                      "Pullup is a challenging upper body exercise where you grip an overhead bar  and lift your body until your chin is above that bar.",
                      TypeId = 2,
                      ImageUrl = "https://calisthenicsworldwide.com/wp-content/uploads/2023/02/152-CWW_20-pull-ups.jpg"
                 },
                    new Exercise()
                 {
                      Id = 4,
                      Name = "Cycling",
                      Description =
                       "Cycling, also, when on a two-wheeled bicycle, called bicycling or biking  is the use of cycles for transport, recreation, exercise or sport. People engaged in cycling are referred to as cyclists,bicyclists, or bikers.",
                      TypeId = 2,
                      ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/21/2022/05/Cube-Axial-WS-12-45369da.jpg?quality=90&resize=620%2C413"
                 },
                     new Exercise()
                 {
                      Id = 5,
                      Name = "Bench Press",
                       Description =
                       "The bench press is a compound exercise that targets the muscles of the upper body. It involves lying on a bench and pressing weight upward using either a barbell or a pair of dumbbells.",
                      TypeId = 3,
                      Sets = "4",
                      Reps = "10 - 12",
                      ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/barbell-bench-press_0.jpg"
                 },
                      new Exercise()
                 {
                      Id = 6,
                      Name = "Squat",
                      Description =
                       "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes",
                      TypeId = 3,
                      Sets = "3-4",
                      Reps = "8 - 10",
                      ImageUrl = "https://www.muscleandfitness.com/wp-content/uploads/2019/02/1109-Barbell-Back-Squat-GettyImages-614107160.jpg?quality=86&strip=all"
                 }
            };

            return exercises.ToArray();
        }
    }
}
