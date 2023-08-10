namespace FitnessSite.Services
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Web.ViewModels.Message;
    using Intarfaces;
    using Data.Models;
    using Web.Data;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<ICollection<MessageViewModel>?> MyMessagesAsync(string userId)
        {
            bool isUserHaveMessages =
                await IsUserHaveMessagesAsync(userId);
            if (!isUserHaveMessages)
            {
                return null;
            }


            ICollection<MessageViewModel> messages =
                await dbContext.Messages!.Where(m => m.RecipientId.ToString() == userId)
                .Select(m => new MessageViewModel
                {
                    SenderFirstName = m.SenderFirstName,
                    SenderLastName = m.SenderLastName,
                    Description = m.Description,
                    Question = m.Questions,
                    SenderId = m.SenderId
                })
                .ToArrayAsync();

            return messages;
        }
        private async Task<bool> IsUserHaveMessagesAsync(string userId)
        {
            return
                await dbContext.Messages!
                .Where(m => m.RecipientId.ToString() == userId).AnyAsync();
        }

    }
}
