namespace FitnessSite.Services.Intarfaces
{

    public interface IUserService
    {
        Task<bool> IsUserExistAsync(string id);

        public Task<List<string>> AllUserExercisesNames(string userId);

        Task<bool> IsUserHaveTrainerAsync(string id);

        Task<bool> IsUserHaveThisTrainerAsync(string userId, string trainerId);
    }
}
