namespace FitnessSite.Services.Intarfaces
{
    using Web.ViewModels.TypeExercise;

    public interface IExerciseService
    {
        public Task<IEnumerable<TypeExerciseViewModel>> AllExerciseAsync();

        public Task AddExerciseAsync(int id, string userId);

        public Task<bool> IsExersiceExistById(int id);

        public Task<bool> IsExerciseExistInThisTrainingAsync(int id,string userId);
    }
}
