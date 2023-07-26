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
                Where(e => e.UserId == null).
                Select(e => new AllExerciseViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    ImageUrl = e.ImageUrl,
                    Reps = e.Reps,
                    Sets = e.Sets,
                    Kilograms = e.Kilogram,
                    TargetMuscle = dbContext.MuscleExercises
                     .Where(me => me.ExerciseId == e.Id)
                     .Select(me => me.Muscle.Name)
                     .ToList(),
                }).ToArray()
                }).ToArrayAsync();

            return models;
        }

        public async Task AddExerciseAsync(Guid id, string userId)
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

        public async Task<bool> IsExersiceExistById(Guid id)
        {
            return await dbContext.Exercises.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> IsExerciseExistInThisTrainingAsync(Guid id, string userId)
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
                    Kilograms = e.Kilogram,
                    TargetMuscle = dbContext.MuscleExercises
                    .Where(me => me.ExerciseId == e.Id)
                    .Select(me => me.Muscle.Name)
                    .ToList(),
                })
                .ToArray()
                }).ToArrayAsync();

            return models;
        }

        public async Task<string> GetExerciseNameByIdAsync(Guid id)
        {
            Exercise exercise = await dbContext.Exercises.FirstAsync(x => x.Id == id);

            return exercise.Name;
        }

        public async Task<GetExerciseToEditViewModel> GetExerciseToEditAsync(Guid id)
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

        public async Task EditExerciseAsync(Guid id, EditExerciseViewModel model, string userId)
        {
            Exercise exercise = await dbContext.
                Exercises.Include(e => e.MuscleExercises).FirstAsync(e => e.Id == id);
            ApplicationUser user = await dbContext.Users.FirstAsync(u => u.Id.ToString() == userId);
            Guid? trainingId = user.TrainingId;

            if (!exercise.UserId.HasValue)
            {
                Exercise exerciseToAdd = new Exercise()
                {
                    Description = exercise.Description,
                    ImageUrl = exercise.ImageUrl,
                    Name = exercise.Name,
                    UserId = Guid.Parse(userId),
                    TypeId = exercise.TypeId,
                    Reps = model.Reps,
                    Sets = model.Sets,
                    Kilogram = model.Kilogram
                };

                foreach (int muscleId in exercise.MuscleExercises.Select(me => me.MuscleId))
                {
                    exerciseToAdd.MuscleExercises.Add(new MuscleExercise()
                    {
                        ExerciseId = exerciseToAdd.Id,
                        MuscleId = muscleId,
                    });
                }

                await dbContext.AddAsync(exerciseToAdd);

                TrainingExercise trainingExercise =
                    await dbContext.TrainingExercises!
                    .FirstAsync(te => te.ExerciseId == id && te.TrainingId == trainingId);

                dbContext.TrainingExercises!.Remove(trainingExercise);
                await dbContext.SaveChangesAsync();

                TrainingExercise trainingExerciseToAdd = new TrainingExercise()
                {
                    ExerciseId = exerciseToAdd.Id,
                    TrainingId = trainingId
                };

                dbContext.TrainingExercises.Add(trainingExerciseToAdd);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                exercise.Sets = model.Sets;
                exercise.Reps = model.Reps;
                exercise.Kilogram = model.Kilogram;
            }

            await dbContext.SaveChangesAsync();
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

        public async Task<bool> IsEditExerciseAddToTraining(string id,string userId)
        {
            Exercise originalExercise = await 
                dbContext.Exercises.FirstAsync(e => e.Id.ToString() == id);

            ApplicationUser? user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            string? trainingId = user!.TrainingId.ToString();
                

            TrainingExercise[] userExercises = 
                await dbContext.TrainingExercises!.Include(te => te.Exercise).
                Where(te => te.TrainingId.ToString() == trainingId).ToArrayAsync();

            return userExercises.Any(te => te.Exercise.Name == originalExercise.Name && te.Exercise.UserId.ToString() == userId);
        }
    }
}
