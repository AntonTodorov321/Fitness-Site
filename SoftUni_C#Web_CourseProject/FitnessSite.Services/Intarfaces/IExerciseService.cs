namespace FitnessSite.Services.Intarfaces
{
    using Web.ViewModels.Exercise;
    using Web.ViewModels.TypeExercise;

    public interface IExerciseService
    {
        public Task<IEnumerable<TypeExerciseViewModelAllExrcises>> AllExerciseWithUserAsync(string userId);

        public Task<IEnumerable<TypeExerciseViewModelAllExrcises>> AllExerciseWithoutUserAsync();

        public Task AddExerciseAsync(string id, string userId);

        public Task<bool> IsExersiceExistByIdAsync(string id);

        public Task<bool> IsExerciseExistInThisTrainingAsync(string id,string userId);

        public Task<string> GetExerciseNameByIdAsync(string id);

        public Task<GetExerciseToEditViewModel> GetExerciseToEditAsync(string id);

        public Task EditExerciseAsync(string id,EditExerciseViewModel model, string userId);

        public Task<bool> IsEditExerciseAddToTrainingAsync(string id, string userId);

        public Task<EditGlobalExerciseViewModel> GetGlobalExerciseToEditAsync(string id);

        public Task EditGlobalExerciseAsync(string id, EditGlobalExerciseViewModel model);
    }
}
