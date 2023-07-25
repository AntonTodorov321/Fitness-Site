namespace FitnessSite.Services.Intarfaces
{
    using FitnessSite.Web.ViewModels.Training;

    public interface ITrainingService
    {
        Task<TrainingViewModel?> GetTrainingAsync(string userId);

        Task RemoveExerciseFromTrainingAsync(Guid exersiceId, string userId);

        Task<bool> IsExerciseExistInTrainingAsync(string userId, Guid exerciseId);

        Task StartTraining(Guid id);
    }
}
