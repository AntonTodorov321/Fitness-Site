namespace FitnessSite.Web.Areas.Trainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Infastructure.Extensions;
    using ViewModels.Message;
    using Services.Intarfaces;

    public class MessageController : BaseTrainerController
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }


        public async Task<IActionResult> All()
        {
            string userId = User.GetById();

            ICollection<MessageViewModel>? messages =
                await messageService.MyMessagesAsync(userId);

            return View(messages);
        }
    }
}
