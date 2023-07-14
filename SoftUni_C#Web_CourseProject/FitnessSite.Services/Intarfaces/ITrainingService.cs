namespace FitnessSite.Services.Intarfaces
{
    using FitnessSite.Web.ViewModels.Training;

    public interface ITrainingService
    {
        Task<TrainingViewModel> GetTrainingAsync(string userId);
    }
}
