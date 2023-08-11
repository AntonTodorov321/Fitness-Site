namespace FitnessSite.Services.Tests
{
    using FitnessSite.Services.Intarfaces;
    using Microsoft.EntityFrameworkCore;

    using Web.Data;

    using static DatabaseSeeder;

    public class ExerciseServiceTests
    {
        private FitnessSiteDbContext dbContext;
        private DbContextOptions<FitnessSiteDbContext> dbOptions;

        private IExerciseService exerciseService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<FitnessSiteDbContext>()
                .UseInMemoryDatabase("FitnessSiteInMemory" + Guid.NewGuid().ToString())
                .Options;
            dbContext = new FitnessSiteDbContext(dbOptions);

            dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);

            exerciseService = new ExerciseService(dbContext);
        }

        [Test]
        public async Task AllExerciseWithUserAsyncShoudReturnCorrectDate()
        {
            string userId = User.Id.ToString();

            var result = exerciseService.AllExerciseWithUserAsync(userId);

            Assert.IsNotNull(result);
        }
    }
}