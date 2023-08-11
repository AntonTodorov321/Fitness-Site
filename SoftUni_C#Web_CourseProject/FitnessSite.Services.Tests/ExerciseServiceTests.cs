namespace FitnessSite.Services.Tests
{
    using Data.Models;
    using Intarfaces;
    using UnitTests;

    [TestFixture]
    public class ExerciseServiceTests : UnitTestsBase
    {
        private IExerciseService exerciseService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            exerciseService = new ExerciseService(dbContext);
        }

        [Test]
        public async Task GetExerciseNameByIdAsync_ShouReturnCorrectName()
        {
            string resultName =
                await exerciseService.GetExerciseNameByIdAsync(Exercise.Id.ToString());

            Assert.That(resultName, Is.EqualTo(Exercise.Name));
        }

        [Test]
        public async Task IsExersiceExistByIdAsync_ShoudReturTrue_WhenExerciseExist()
        {
            bool result =
                await exerciseService.IsExersiceExistByIdAsync(Exercise.Id.ToString());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsExersiceExistByIdAsync_ShoudReturFalse_WhenExerciseNotExist()
        {
            bool result =
                await exerciseService.IsExersiceExistByIdAsync(Guid.NewGuid().ToString());

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsEditExerciseAddToTrainingAsync_ShoudReturnFalse_WhenExercise_IsNotAdded()
        {
            bool result =
                await exerciseService.IsEditExerciseAddToTrainingAsync(Exercise.Id.ToString(), ApplicationUserWithoutExercise.Id.ToString());

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsEditExerciseAddToTrainingAsync_ShoudReturnTrue_WhenExercise_IsAdded()
        {
            bool result =
                await exerciseService.IsEditExerciseAddToTrainingAsync(Exercise.Id.ToString(), ApplicationUser.Id.ToString());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsExerciseExistInThisTrainingAsync_ShouReturnTrue_WhenExist()
        {
            bool result =
                await exerciseService.IsExerciseExistInThisTrainingAsync(Exercise.Id.ToString(), ApplicationUser.Id.ToString());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task AddExerciseAsync_ShouAddExercise_InTraining()
        {
            int exerciseCountBefore = dbContext.TrainingExercises!.Count();

            await 
              exerciseService.AddExerciseAsync(Exercise.Id.ToString(),ApplicationUserWithoutExercise.Id.ToString());

            int exerciseCountAfter = dbContext.TrainingExercises!.Count();

            Assert.That(exerciseCountAfter, Is.EqualTo(exerciseCountBefore + 1));
        }

        [Test]
        public async Task AllExerciseWithoutUserAsync_ShoudReturnCorrectData()
        {
            var result =
                await exerciseService.AllExerciseWithoutUserAsync();

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetExerciseToEditAsync_ShouReturCorrectData()
        {
            string exerciseId = Exercise.Id.ToString();

            var result =
                await exerciseService.GetExerciseToEditAsync(exerciseId);

            Assert.IsNotNull(result);

            Exercise? exerciseInDb = 
                dbContext.Exercises.First(e => e.Id.ToString() == exerciseId);
            Assert.That(result.Id, Is.EqualTo(exerciseInDb.Id.ToString()));
            Assert.That(result.Name, Is.EqualTo(exerciseInDb.Name));
        }

        [Test]
        public async Task GetGlobalExerciseToEditAsync_ShouReturnCorrectData()
        {
            string exerciseId = Exercise.Id.ToString();

            var result =
                await exerciseService.GetGlobalExerciseToEditAsync(exerciseId);

            Assert.IsNotNull(result);

            Exercise? exerciseInDb =
                dbContext.Exercises.First(e => e.Id.ToString() == exerciseId);
            Assert.That(result.Id, Is.EqualTo(exerciseInDb.Id.ToString()));
            Assert.That(result.Name, Is.EqualTo(exerciseInDb.Name));
        }
    }
}