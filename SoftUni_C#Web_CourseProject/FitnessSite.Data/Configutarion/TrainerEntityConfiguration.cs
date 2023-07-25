namespace FitnessSite.Data.Configutarion
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class TrainerEntityConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasData(GenerateTrainers());
        }

        private Trainer[] GenerateTrainers()
        {
            List<Trainer> trainers = new List<Trainer>()
            {
                 new Trainer()
                 {
                      Name = "Ivan",
                      Year = 31,
                      PricePerMonth = 89.99m,
                      StartedAt = 23,
                      TelefoneNumber = "0895543981",
                      Email = "ivantrainer@gmail.com",
                      Description = "Hello, my name is Ivan. I know every type of exercise and i will be glad if i work with you! I work mostly with men.",
                      ImageUrl = "https://media.istockphoto.com/id/1072395722/photo/fitness-trainer-at-gym.jpg?s=612x612&w=0&k=20&c=3VBLCgbxG3bGNRp9Sc3tN_7G-g_DxXhGk9rhuZo-jkE="
                 },

                 new Trainer()
                 {
                      Name = "Maria",
                      Year = 28,
                      PricePerMonth = 84.99m,
                      StartedAt = 21,
                      TelefoneNumber = "0875587458",
                      Email = "mariatrainer@gmail.com",
                      Description = "Hello, my name is Maria.I've been going to the gym since i was 16, and when i grow up i decide to become professional trainer. I work mostly with men.",
                      ImageUrl = "https://media.istockphoto.com/id/856797530/photo/portrait-of-a-beautiful-woman-at-the-gym.jpg?s=612x612&w=0&k=20&c=0wMa1MYxt6HHamjd66d5__XGAKbJFDFQyu9LCloRsYU="
                 }
            };

            return trainers.ToArray();
        }
    }
}
