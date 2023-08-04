namespace FitnessSite.Services
{
    using System.Threading.Tasks;

    using Web.ViewModels.Message;
    using Intarfaces;

    public class MessageService : IMessageService
    {
        public MessageViewModel GetMessageToSendAsync(string senderId,
                                                            string recipientId)
        {
            MessageViewModel messageViewModel = new MessageViewModel()
            {
                SenderId = Guid.Parse(senderId),
                RecipientId = Guid.Parse(recipientId)
            };

            return messageViewModel;
        }
    }
}
