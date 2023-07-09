namespace FitnessSite.Services.Intarfaces
{
    using FitnessSite.Web.ViewModels.Training;

    public interface ITrainingServise
    {
        Task<ICollection<TrainingViewModel>> GetTrainingAsync(string userId);
    }
}
