namespace FitnessSite.Services
{
    using System.Threading.Tasks;

    using Web.ViewModels.Message;
    using Intarfaces;
    using Data.Models;
    using Web.Data;

    public class MessageService : IMessageService
    {
        private readonly FitnessSiteDbContext dbContext;

        public MessageService(FitnessSiteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SendMessageAsync(string senderId, string recipientId, MessageViewModel messageViewModel)
        {
            Message message = new Message()
            {
                SenderId = Guid.Parse(senderId),
                RecipientId = Guid.Parse(recipientId),
                Description = messageViewModel.Description,
                Questions = messageViewModel.Question,
                SenderFirstName = messageViewModel.SenderFirstName,
                SenderLastName = messageViewModel.SenderLastName,
            };

            await dbContext.Messages!.AddAsync(message);
            await dbContext.SaveChangesAsync();
        }
    }
}
