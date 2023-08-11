namespace FitnessSite.Services.Tests
{
    using Intarfaces;
    using UnitTests;

    [TestFixture]
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService userService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            userService = new UserService(dbContext);
        }

        [Test] 
        public async Task IsUserExistAsync_ShoudReturnTrue_WhenUserExist()
        {
            bool result =
                await userService.IsUserExistAsync(ApplicationUser.Id.ToString());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsUserExistAsync_ShoudReturnFalse_WhenUserNotExist()
        {
            bool result =
                await userService.IsUserExistAsync(Guid.NewGuid().ToString());

            Assert.IsFalse(result);
        }

        //[Test]
        //public async Task IsUserHaveTrainerAsync_ShoudReturnTrue_WhenUser_HaveTrainer()
        //{
        //    bool result =
        //        await userService.
        //        IsUserHaveTrainerAsync(ApplicationUserWhitTrainer.Id.ToString());

        //    Assert.IsTrue(result);
        //}

        [Test]
        public async Task IsUserHaveTrainerAsync_ShoudReturnFalse_WhenUser_DontHaveTrainer()
        {
            bool result =
                await userService.
                IsUserHaveTrainerAsync(Guid.NewGuid().ToString());

            Assert.IsFalse(result);
        }
    }
}
