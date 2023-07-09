namespace FitnessSite.Data.Configutarion
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class TypeExerciseEntityConfiguration : IEntityTypeConfiguration<TypeExercise>
    {
        public void Configure(EntityTypeBuilder<TypeExercise> builder)
        {
            builder.HasData(GenerateTypeExercices());
        }

        private TypeExercise[] GenerateTypeExercices()
        {
            List<TypeExercise> typeExercises = new List<TypeExercise>()
            {
                  new TypeExercise()
                 {
                      Id = 1,
                      Name = "In Home",
                 },

                  new TypeExercise()
                  {
                      Id = 2,
                      Name = "Outside"
                  },

                  new TypeExercise()
                  {
                      Id = 3,
                      Name = "In the gym"
                  }
            };

            return typeExercises.ToArray();
        }
    }
}
