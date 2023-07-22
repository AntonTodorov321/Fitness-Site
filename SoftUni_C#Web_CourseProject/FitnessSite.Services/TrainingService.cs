namespace FitnessSite.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Data.Models;
    using Web.Data;
    using Web.ViewModels.Exercise;
    using Intarfaces;
    using Web.ViewModels.Training;

    public class TrainingService : ITrainingService
    {
        private readonly FitnessSiteDbContext dbContext;

        public TrainingService(FitnessSiteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TrainingViewModel?> GetTrainingAsync(string userId)
        {
            ApplicationUser user =
                await this.GetApplicationUserByIdAsync(userId);

            Training? training =
                await GetTrainingByUserAsync(user);

            if (training == null)
            {
                return null;
            }

            TrainingViewModel? trainingViewModel = await
                 dbContext.Trainings.
                Select(t => new TrainingViewModel()
                {
                    Id = t.Id,
                    Exercises = dbContext.TrainingExercises!
                     .Where(te => te.TrainingId == t.Id)
                     .Select(te => new AllExerciseViewModel()
                     {
                         Name = te.Exercise.Name,
                         Id = te.Exercise.Id,
                         Description = te.Exercise.Description,
                         ImageUrl = te.Exercise.ImageUrl,
                         Reps = te.Exercise.Reps,
                         Sets = te.Exercise.Sets,
                         Kilograms = te.Exercise.Kilogram,
                         TargetMuscle =
                         te.Exercise.MuscleExercises.
                         Where(me => me.ExerciseId == te.Exercise.Id).
                         Select(me => me.Muscle.Name).ToList()
                     }).ToList()
                }).FirstOrDefaultAsync(t => t.Id == training.Id);


            return trainingViewModel;
        }

        public async Task<bool> isExerciseExistInTrainingAsync
            (string userId, Guid exerciseId)
        {
            ApplicationUser user = await GetApplicationUserByIdAsync(userId);

            Training? training = await GetTrainingByUserAsync(user);

            return await dbContext.Trainings
                .AnyAsync(t => t.TrainingExercises.
                Any(te => te.TrainingId == training!.Id && te.ExerciseId == exerciseId));
        }

        public async Task RemoveExerciseFromTrainingAsync(Guid exersiceId, string userId)
        {
            ApplicationUser user = await GetApplicationUserByIdAsync(userId);

            Training? training = await GetTrainingByUserAsync(user);

            TrainingExercise trainingExerciseToRemove = new TrainingExercise()
            {
                ExerciseId = exersiceId,
                TrainingId = training!.Id
            };

            dbContext.TrainingExercises!.Remove(trainingExerciseToRemove);

            Exercise exercise =
                await dbContext.Exercises.FirstAsync(e => e.Id == exersiceId);

            if (exercise.UserId.HasValue)
            {
                dbContext.Exercises.Remove(exercise);
            }

            await dbContext.SaveChangesAsync();
        }


        private async Task<ApplicationUser> GetApplicationUserByIdAsync(string userId)
        {
            return await dbContext.Users.FirstAsync(u => u.Id.ToString() == userId);
        }

        private async Task<Training?> GetTrainingByUserAsync(ApplicationUser user)
        {
            return await dbContext.Trainings.
                FirstOrDefaultAsync(t => t.Id.ToString() == user.TrainingId.ToString());
        }
    }
}
