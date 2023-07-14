namespace FitnessSite.Services
{
    using System.Collections.Generic;
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
            ApplicationUser user = dbContext.Users.First(u => u.Id.ToString() == userId);

            Training? training = dbContext.Trainings.FirstOrDefault(t => t.Id.ToString() == user.TrainingId.ToString());

            TrainingViewModel? trainingViewModel =
                 dbContext.Trainings.
                Select(t => new TrainingViewModel()
                {
                    Id = t.Id,
                    Exercises = dbContext.TrainingExercises
                     .Where(te => te.TrainingId == t.Id)
                     .Select(te => new AllExerciseViewModel()
                     {
                         Name = te.Esercise.Name,
                     }).ToList()
                }).FirstOrDefault(t => t.Id == training.Id);


                return trainingViewModel;
        }
    }
}
