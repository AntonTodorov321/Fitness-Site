namespace FitnessSite.Services.Tests.UnitTests
{
    using Data.Models;
    using Mock;
    using Web.Data;

    using Exercise = Data.Models.Exercise;

    public class UnitTestsBase
    {
        protected FitnessSiteDbContext dbContext;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbContext = DatabaseMock.Instance;
            SeedDatabase();
        }


        public Exercise Exercise { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; } = null!;

        public ApplicationUser ApplicationUserWithoutExercise { get; set; } = null!;

        public Training Training { get; set; } = null!;

        public TrainingExercise TrainingExercise { get; set; } = null!;

        private void SeedDatabase()
        {
            Exercise = new Exercise()
            {
                Id = Guid.Parse("6f41591d-22c0-48df-99c5-79a48b1f87cb"),
                Name = "Push-Ups",
                Description =
                      "An exercise in which a person, keeping a prone position with thehandspalms down under the shoulders",
                TypeId = 1,
                Sets = "4",
                Reps = "10",
                ImageUrl = "https://blog.nasm.org/hubfs/power-pushups.jpg",
                UserId = new Guid("140d0fdd-d82f-494c-ae77-50c6d5251424")
            };

            ApplicationUser = new ApplicationUser()
            {
                Id = Guid.Parse("140d0fdd-d82f-494c-ae77-50c6d5251424"),
                Email = "ivantrainer@gmail.com",
                NormalizedEmail = "IVANTRAINER@GMAIL.COM",
                UserName = "ivantrainer@gmail.com",
                NormalizedUserName = "IVANTRAINER@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEPkFrXPoUKAiePrdfD7MpV8GM3DDLiGHeL0t59CRhINfNeFNYk5KsFBtvu4333byRQ==",
                SecurityStamp = "BNB3HKKNVR6EQGG33PZ2PKZZ2E3A3BRM",
                ConcurrencyStamp = "e58d020a-8b2e-4638-ab42-d61fc242ed18",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                TrainingId = Guid.Parse("fe8dbe30-9748-47d7-acf9-d7fed112de48"),
            };

            ApplicationUserWithoutExercise = new ApplicationUser()
            {
                Email = "ivantrainer@gmail.com",
                NormalizedEmail = "IVANTRAINER@GMAIL.COM",
                UserName = "ivantrainer@gmail.com",
                NormalizedUserName = "IVANTRAINER@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEPkFrXPoUKAiePrdfD7MpV8GM3DDLiGHeL0t59CRhINfNeFNYk5KsFBtvu4333byRQ==",
                SecurityStamp = "BNB3HKKNVR6EQGG33PZ2PKZZ2E3A3BRM",
                ConcurrencyStamp = "e58d020a-8b2e-4638-ab42-d61fc242ed18",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
            };

            Training = new Training()
            {
                Id = Guid.Parse("fe8dbe30-9748-47d7-acf9-d7fed112de48"),
                ApplicationUserId = Guid.Parse("6f41591d-22c0-48df-99c5-79a48b1f87cb")
            };

            TrainingExercise = new TrainingExercise()
            {
                Training = Training,
                Exercise = Exercise
            };

            dbContext.Users.Add(ApplicationUserWithoutExercise);
            dbContext.Exercises.Add(Exercise);
            dbContext.Users.Add(ApplicationUser);
            dbContext.Trainings.Add(Training);
            dbContext.TrainingExercises!.Add(TrainingExercise);

            dbContext.SaveChanges();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            dbContext.Dispose();
        }
    }
}
