namespace FitnessSite.Services
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using Intarfaces;
    using Web.Data;
    using Web.ViewModels.Exercise;
    using Web.ViewModels.TypeExercise;
    using Data.Models;

    public class ExerciseService : IExerciseService
    {
        private readonly FitnessSiteDbContext dbContext;

        public ExerciseService(FitnessSiteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TypeExerciseViewModel>> AllExerciseWithUserAsync(string userId)
        {
            ApplicationUser user = dbContext.Users.First(u => u.Id.ToString() == userId);
            Guid? trainingId = user?.TrainingId;

            IEnumerable<TypeExerciseViewModel> models =
                await dbContext.TypeExercises.Select(t => new TypeExerciseViewModel()
                {
                    Name = t.Name,
                    AllExercises = dbContext.Exercises.
                Where(e => e.TypeId == t.Id && !(e.TrainingExercises.
                Any(te => te.TrainingId == trainingId))).
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
                     .ToList(),
                }).ToArray()
                }).ToArrayAsync();

            return models;
        }

        public async Task AddExerciseAsync(int id, string userId)
        {
            Exercise exerciseToAdd =
                dbContext.Exercises.First(e => e.Id == id);

            ApplicationUser user = dbContext.Users.First(u => u.Id.ToString() == userId);

            if (user.TrainingId == null)
            {
                Training training = new Training()
                {
                    ApplicationUserId = user.Id,
                };

                user.TrainingId = training.Id;
                await dbContext.Trainings.AddAsync(training);
            }

            TrainingExercise trainingExercise = new TrainingExercise()
            {
                ExerciseId = exerciseToAdd.Id,
                TrainingId = (Guid)user.TrainingId!
            };

            await dbContext.TrainingExercises!.AddAsync(trainingExercise);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExersiceExistById(int id)
        {
            return await dbContext.Exercises.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> IsExerciseExistInThisTrainingAsync(int id, string userId)
        {
            Exercise exerciseToAdd =
                dbContext.Exercises.First(e => e.Id == id);

            ApplicationUser user = dbContext.Users.First(u => u.Id.ToString() == userId);

            return await dbContext.TrainingExercises!.AnyAsync(te => te.TrainingId == user.TrainingId
            && te.ExerciseId == exerciseToAdd.Id);
        }

        public async Task<IEnumerable<TypeExerciseViewModel>> AllExerciseWithoutUserAsync()
        {
            IEnumerable<TypeExerciseViewModel> models = await dbContext.TypeExercises.
                Select(t => new TypeExerciseViewModel()
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
                    .ToList(),
                })
                .ToArray()
                }).ToArrayAsync();

            return models;
        }

        public async Task<string> GetExerciseNameByIdAsync(int id)
        {
            Exercise exercise = await dbContext.Exercises.FirstAsync(x => x.Id == id);

            return exercise.Name;
        }

        public async Task<GetExerciseToEditViewModel> GetExerciseToEditAsync(int id)
        {
            Exercise exercise = await dbContext.Exercises.
                FirstAsync(e => e.Id == id);

            GetExerciseToEditViewModel editViewModel = new GetExerciseToEditViewModel()
            {
                Id = id,
                Kilogram = exercise.Kilogram,
                Reps = exercise.Reps,
                Sets = exercise.Sets,
                Name = exercise.Name,
            };

            return editViewModel;
        }

        public async Task EditExerciseAsync(int id, EditExerciseViewModel model)
        {
            Exercise exercise = await dbContext.Exercises.FirstAsync(e => e.Id == id);

            exercise.Sets = model.Sets;
            exercise.Reps = model.Reps;
            exercise.Kilogram = model.Kilogram;

            await dbContext.SaveChangesAsync();
        }
    }
}
