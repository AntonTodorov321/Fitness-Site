//namespace FitnessSite.Data.Configutarion
//{
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;

//    using Models;

//    public class MuscleEntityConfiguration : IEntityTypeConfiguration<Muscle>
//    {
//        public void Configure(EntityTypeBuilder<Muscle> builder)
//        {
//            builder.HasData(GenerateMuscle());
//        }

//        private Muscle[] GenerateMuscle()
//        {
//            ICollection<Muscle> muscles = new HashSet<Muscle>()
//            {
//                new Muscle()
//                {
//                    Id = 1,
//                    Name = "Biceps"
//                },

//                new Muscle()
//                {
//                    Id = 2,
//                    Name = "Triceps"
//                },

//                new Muscle()
//                {
//                    Id = 3,
//                    Name = "Shoulder"
//                },

//                new Muscle()
//                {
//                    Id = 4,
//                    Name = "Legs"
//                },

//                new Muscle()
//                {
//                    Id = 5,
//                    Name = "Chest"
//                },

//                new Muscle()
//                {
//                    Id = 6,
//                    Name = "Abs"
//                },
//                new Muscle()
//                {
//                    Id = 7,
//                    Name = "Back"
//                }
//            };

//            return muscles.ToArray();
//        }
//    }
//}
