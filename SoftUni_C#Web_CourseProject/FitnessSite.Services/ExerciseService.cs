namespace FitnessSite.Services
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using Intarfaces;
    using Web.Data;
    using Web.ViewModels.Exercise;
    using Web.ViewModels.TypeExercise;

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
    }
}
