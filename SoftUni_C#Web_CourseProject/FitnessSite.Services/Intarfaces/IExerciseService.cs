namespace FitnessSite.Services.Intarfaces
{
    using FitnessSite.Web.ViewModels.Exercise;
    using Web.ViewModels.TypeExercise;

    public interface IExerciseService
    {
        public Task<IEnumerable<TypeExerciseViewModel>> AllExerciseWithUserAsync(string userId);

        public Task<IEnumerable<TypeExerciseViewModel>> AllExerciseWithoutUserAsync();

        public Task AddExerciseAsync(Guid id, string userId);

        public Task<bool> IsExersiceExistById(Guid id);

        public Task<bool> IsExerciseExistInThisTrainingAsync(Guid id,string userId);

        public Task<string> GetExerciseNameByIdAsync(Guid id);

        public Task<GetExerciseToEditViewModel> GetExerciseToEditAsync(Guid id);

        public Task EditExerciseAsync(Guid id,EditExerciseViewModel model, string userId);
    }
}
