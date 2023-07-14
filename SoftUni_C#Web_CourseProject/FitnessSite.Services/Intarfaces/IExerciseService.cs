namespace FitnessSite.Services.Intarfaces
{
    using FitnessSite.Web.ViewModels.Exercise;
    using Web.ViewModels.TypeExercise;

    public interface IExerciseService
    {
        public Task<IEnumerable<TypeExerciseViewModel>> AllExerciseWithUserAsync(string userId);

        public Task<IEnumerable<TypeExerciseViewModel>> AllExerciseWithoutUserAsync();

        public Task AddExerciseAsync(int id, string userId);

        public Task<bool> IsExersiceExistById(int id);

        public Task<bool> IsExerciseExistInThisTrainingAsync(int id,string userId);

        public Task<string> GetExerciseNameByIdAsync(int id);

        public Task<EditExerciseViewModel> GetExerciseToEditAsync(int id);
    }
}
