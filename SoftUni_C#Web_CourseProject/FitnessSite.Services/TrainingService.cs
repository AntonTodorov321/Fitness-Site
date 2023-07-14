namespace FitnessSite.Services
{
    using System.Threading.Tasks;

    using Data.Models;
    using Web.Data;
    using Web.ViewModels.Exercise;
    using Intarfaces;
    using Web.ViewModels.Training;
    using Microsoft.EntityFrameworkCore;

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
                await dbContext.Users.FirstAsync(u => u.Id.ToString() == userId);

            Training? training =
                await dbContext.Trainings.
                FirstOrDefaultAsync(t => t.Id.ToString() == user.TrainingId.ToString());

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
                         Name = te.Esercise.Name,
                         Id = te.Esercise.Id,
                         Description = te.Esercise.Description,
                         ImageUrl = te.Esercise.ImageUrl,
                         Reps = te.Esercise.Reps,
                         Sets = te.Esercise.Sets,
                         TargetMuscle =
                         te.Esercise.MuscleExercises.
                         Where(me => me.ExerciseId == te.Esercise.Id).
                         Select(me => me.Muscle.Name).ToList()
                     }).ToList()
                }).FirstOrDefaultAsync(t => t.Id == training.Id);


            return trainingViewModel;
        }
    }
}
