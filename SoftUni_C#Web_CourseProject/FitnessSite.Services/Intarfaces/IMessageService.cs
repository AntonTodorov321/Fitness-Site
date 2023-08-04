namespace FitnessSite.Services.Intarfaces
{
    using Web.ViewModels.Message;

    public interface IMessageService
    {
        MessageViewModel GetMessageToSendAsync(string senderId, string recipientId);
    }
}
