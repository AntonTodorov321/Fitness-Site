namespace FitnessSite.Services.Intarfaces
{
    using FitnessSite.Web.ViewModels.Training;

    public interface ITrainingService
    {
        Task<TrainingViewModel?> GetTrainingAsync(string userId);

        Task RemoveExerciseFromTrainingAsync(int exersiceId, string userId);

        Task<bool> isExerciseExistInTrainingAsync(string userId, int exerciseId);
    }
}
