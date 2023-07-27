namespace FitnessSite.Services.Intarfaces
{
    using Web.ViewModels.Trainer;

    public interface ITrainerService
    {
        Task<List<AllTrainerViewModel>> GetAllTrainersAsync();

        Task<DetailsTrainerViewModel> GetTrainerDetailsAsync(string id);

        Task<bool> IsTrainerExesitAsync(string id);

        Task<string> GetFullNameTrainerById(string id);

        Task<bool> IsUserHaveTrainerAsync(string id);
    }
}
