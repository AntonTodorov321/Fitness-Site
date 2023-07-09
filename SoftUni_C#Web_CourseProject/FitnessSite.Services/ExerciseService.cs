namespace FitnessSite.Services
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using Intarfaces;
    using Web.Data;
    using Web.ViewModels.Exercise;
    using Web.ViewModels.TypeExercise;
    using FitnessSite.Data.Models;

    public class ExerciseService : IExerciseService
    {
        private readonly FitnessSiteDbContext dbContext;

        public ExerciseService(FitnessSiteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TypeExerciseViewModel>> AllExerciseAsync()
        {
            return await dbContext.TypeExercises.Select(t => new TypeExerciseViewModel()
            {
                Name = t.Name,
                AllExercises = dbContext.Exercises.Where(e => e.TypeId == t.Id).
                 Select(e => new AllExerciseViewModel()
                 {
                     Id = e.Id,
                     Name = e.Name,
                     Description = e.Description,
                     ImageUrl = e.ImageUrl,
                     Reps = e.Reps,
                     Sets = e.Sets,
                     TargetMuscle = dbContext.MuscleExercises
                     .Where(me => me.ExerciseId == e.Id)
                     .Select(me => me.Muscle.Name)
                     .ToList()
                 }).ToArray()
            }).ToArrayAsync();
        }

        public async Task AddExerciseAsync(int id, string userId)
        {
            Exercise exerciseToAdd = 
                dbContext.Exercises.First(e => e.Id == id);

            ApplicationUser user = dbContext.Users.First(u => u.Id.ToString() == userId);

            if (user.TrainingId == Guid.Empty)
            {
                Training training = new Training()
                {
                    ApplicationUserId = user.Id,
                };

                user.TrainingId = training.Id;
                await dbContext.Trainings.AddAsync(training);
            }


            exerciseToAdd.TrainingId = user.TrainingId.ToString();

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExersiceExistById(int id)
        {
            return await dbContext.Exercises.AnyAsync(e => e.Id == id);
        }
    }
}
