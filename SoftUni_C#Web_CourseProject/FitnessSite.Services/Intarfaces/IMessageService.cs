namespace FitnessSite.Services.Intarfaces
{
    using Web.ViewModels.Message;

    public interface IMessageService
    {
        Task SendMessageAsync(string senderId, string recipientId, SendMessageViewModel messageViewModel);

        Task<ICollection<AllMessageViewModel>?> MyMessagesAsync(string userId);

        Task<bool> IsMessageExistAsync(string id);

        Task<ShowDetailsMessageViewModel> GetMessageDetailsAsync(string id);

        Task DeleteMessageAsync(string id);

        Task AssigningUserToTrainerAsync(string userId, string userTrainerId);

        Task<ICollection<AllMessageViewModel>?> MyMessagesAsTrainerAsync(string userId);
    }
}
