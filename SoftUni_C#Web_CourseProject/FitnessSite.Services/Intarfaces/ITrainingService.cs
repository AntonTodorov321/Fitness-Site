namespace FitnessSite.Services.Intarfaces
{
    using FitnessSite.Web.ViewModels.Training;

    public interface ITrainingService
    {
        Task<TrainingViewModel?> GetTrainingAsync(string userId);

        Task RemoveExerciseFromTrainingAsync(string exersiceId, string userId);

        Task<bool> IsExerciseExistInTrainingAsync(string userId, string exerciseId);

        Task StartTraining(string id);
    }
}
