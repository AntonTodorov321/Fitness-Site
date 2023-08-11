namespace FitnessSite.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Web.Data;
    using Intarfaces;
    using Data.Models;

    public class UserService : IUserService
    {
        private readonly FitnessSiteDbContext dbContext;

        public UserService(FitnessSiteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> IsUserExistAsync(string id)
        {
            bool isUserExist =
                await dbContext.Users.AnyAsync(u => u.Id.ToString() == id);

            return isUserExist;
        }

        public async Task<List<string>> AllUserExercisesNames(string userId)
        {
            if (userId == null)
            {
                return new List<string>();
            }
            ApplicationUser user =
                await dbContext.Users.FirstAsync(u => u.Id.ToString() == userId);
            return
                await dbContext.TrainingExercises!.
                Include(te => te.Exercise).
                Where(te => te.TrainingId == user.TrainingId).
                Select(te => te.Exercise.Name).
                ToListAsync();
        }

        public async Task<bool> IsUserHaveTrainerAsync(string id)
        {
            ApplicationUser? user =
                await dbContext.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id);

            if (user == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(user.TrainerId.ToString()))
            {
                return false;
            }

            return true;
        }

        public async Task<bool> IsUserHaveThisTrainerAsync(string userId, string trainerId)
        {
            ApplicationUser? user =
               await dbContext.Users.FirstAsync(u => u.Id.ToString() == userId);

            return user.TrainerId.ToString()!.ToUpper() == trainerId;
        }
    }
}
