namespace FitnessSite.Services
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

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

        public async Task SendMessageAsync(string senderId, string recipientId, SendMessageViewModel messageViewModel)
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

        public async Task<ICollection<AllMessageViewModel>?> MyMessagesAsync(string userId)
        {
            bool isUserHaveMessages =
                await IsUserHaveMessagesAsync(userId);
            if (!isUserHaveMessages)
            {
                return null;
            }


            ICollection<AllMessageViewModel> messages =
                await dbContext.Messages!.Where(m => m.RecipientId.ToString() == userId)
                .Select(m => new AllMessageViewModel
                {
                    Id = m.Id.ToString(),
                    SenderFirstName = m.SenderFirstName,
                    SenderLastName = m.SenderLastName,
                    Description = m.Description
                })
                .ToArrayAsync();

            return messages;
        }

        public async Task<bool> IsMessageExistAsync(string id)
        {
            return await dbContext.Messages!.AnyAsync(m => m.Id.ToString() == id);
        }

        public async Task<ShowDetailsMessageViewModel> GetMessageDetailsAsync(string id)
        {
            ShowDetailsMessageViewModel message = await dbContext.Messages!.
                Select(m => new ShowDetailsMessageViewModel()
                {
                    Id = m.Id.ToString(),
                    Description = m.Description,
                    Questions = m.Questions,
                    SenderId = m.SenderId.ToString()
                })
                .FirstAsync(m => m.Id == id);

            return message;
        }

        public async Task DeleteMessageAsync(string id)
        {
            Message messageToDelete = 
                await dbContext.Messages!.FirstAsync(m => m.Id.ToString() == id);

            dbContext.Messages!.Remove(messageToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task AssigningUserToTrainerAsync(string userId, string userTrainerId)
        {
            ApplicationUser user = 
                await dbContext.Users.FirstAsync(u => u.Id.ToString() == userId);

            Trainer trainer = await dbContext.Trainers.
                FirstAsync(t => t.ApplicationUserId.ToString() == userTrainerId);
            string trainerId = trainer.Id.ToString();

            user.TrainerId = Guid.Parse(trainerId);

            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<AllMessageViewModel>?> MyMessagesAsTrainerAsync(string userId)
        {
            Trainer trainer =
                await dbContext.Trainers
                .FirstAsync(t => t.ApplicationUserId.ToString() == userId);
            string trainerId = trainer.Id.ToString();

            bool isUserHaveMessages =
                await IsUserHaveMessagesAsync(trainerId);
            if (!isUserHaveMessages)
            {
                return null;
            }


            ICollection<AllMessageViewModel> messages =
                await dbContext.Messages!.Where(m => m.RecipientId.ToString() == trainerId)
                .Select(m => new AllMessageViewModel
                {
                    Id = m.Id.ToString(),
                    SenderFirstName = m.SenderFirstName,
                    SenderLastName = m.SenderLastName,
                    Description = m.Description
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
