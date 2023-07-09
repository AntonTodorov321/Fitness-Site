namespace FitnessSite.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FitnessSite.Data.Models;
    using FitnessSite.Web.Data;
    using FitnessSite.Web.ViewModels.Exercise;
    using Intarfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Training;

    internal class TrainingService : ITrainingServise
    {
        private readonly FitnessSiteDbContext dbContext;

        public TrainingService(FitnessSiteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<TrainingViewModel>> GetTrainingAsync(string userId)
        {
            ApplicationUser user = dbContext.Users.First(u => u.Id.ToString() == userId);

            Training training = dbContext.Trainings.First(t => t.Id.ToString() == user.TrainerId.ToString());

            ICollection<TrainingViewModel> trainingViewModels = await
                dbContext.Trainings.Select(t => new TrainingViewModel()
                {
                    Exercises = dbContext.TrainingExercises
                     .Where(te => te.TrainingId == t.Id)
                     .Select(te => new AllExerciseViewModel()
                     {
                         Name = te.Esercise.Name
                     })
                     .ToList()
                }).ToListAsync();
                
                return trainingViewModels;
        }
    }
}
