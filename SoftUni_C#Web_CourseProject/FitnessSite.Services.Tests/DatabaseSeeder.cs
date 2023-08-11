namespace FitnessSite.Services.Tests
{
    using FitnessSite.Data.Models;
    using FitnessSite.Web.Data;

    public static class DatabaseSeeder
    {
        public static Exercise Exercise;
        public static ApplicationUser User;

        public static void SeedDatabase(FitnessSiteDbContext dbContext)
        {
            Exercise = new Exercise()
            {
                Name = "Push-Ups",
                Description =
                      "An exercise in which a person, keeping a prone position with thehandspalms down under the shoulders",
                TypeId = 1,
                Sets = "4",
                Reps = "10",
                ImageUrl = "https://blog.nasm.org/hubfs/power-pushups.jpg",
                UserId = new Guid("673FC005-4FBB-403B-8931-61C02F901F56")
            };
            User = new ApplicationUser()
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

            dbContext.Users.Add(User);
            dbContext.Exercises.Add(Exercise);

            dbContext.SaveChanges();
        }
    }
}
