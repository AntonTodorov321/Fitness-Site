namespace FitnessSite.Services.Intarfaces
{
    using Web.ViewModels.Exercise;
    using Web.ViewModels.TypeExercise;

    public interface IExerciseService
    {
        public Task<IEnumerable<TypeExerciseViewModelAllExrcises>> AllExerciseWithUserAsync(string userId);

        public Task<IEnumerable<TypeExerciseViewModelAllExrcises>> AllExerciseWithoutUserAsync();

        public Task AddExerciseAsync(Guid id, string userId);

        public Task<bool> IsExersiceExistById(Guid id);

        public Task<bool> IsExerciseExistInThisTrainingAsync(Guid id,string userId);

        public Task<string> GetExerciseNameByIdAsync(Guid id);

        public Task<GetExerciseToEditViewModel> GetExerciseToEditAsync(Guid id);

        public Task EditExerciseAsync(Guid id,EditExerciseViewModel model, string userId);

        public Task<List<string>> AllUserExercisesNames(string userId);

        public Task<bool> IsEditExerciseAddToTraining(string id, string userId);

        public Task<EditGlobalExerciseViewModel> GetGlobalExerciseToEditAsync(string id);
    }
}
