namespace FitnessSite.Services.Intarfaces
{
    using Web.ViewModels.Message;

    public interface IMessageService
    {
        Task SendMessageAsync(string senderId, string recipientId, MessageViewModel messageViewModel);
    }
}
