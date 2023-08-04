namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Intarfaces;
    using Infastructure.Extensions;
    using ViewModels.Message;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class MessageController : Controller
    {
        private readonly ITrainerService trainerService;
        private readonly IMessageService messageService;

        public MessageController(ITrainerService trainerService,
                                 IMessageService messageService)
        {
            this.trainerService = trainerService;
            this.messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage(string id)
        {
            bool isTrainerExist =
                await trainerService.IsTrainerExesitAsync(id);
            if (!isTrainerExist)
            {
                TempData[WarningMessage] =
                    "This trainer does not exist! Pleace select existing one";
                return RedirectToAction("All", "Trainer");
            }

            bool isUserHaveTrainer =
                await trainerService.IsUserHaveTrainerAsync(User.GetById());
            if (isUserHaveTrainer)
            {
                TempData[WarningMessage] =
                    "You allready have trainer. You can have only one";
                return RedirectToAction("All", "Trainer");
            }

            return View(new MessageViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageViewModel message, string id)
        {
            bool isTrainerExist =
               await trainerService.IsTrainerExesitAsync(id);
            if (!isTrainerExist)
            {
                TempData[WarningMessage] =
                    "This trainer does not exist! Pleace select existing one";
                return RedirectToAction("All", "Trainer");
            }

            string senderId = User.GetById();

            try
            {
                await messageService.SendMessageAsync(senderId, id, message);
                TempData[SuccessMessage] = "You successfully send a message";
                return RedirectToAction("All", "Trainer");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return this.RedirectToAction("Index", "Home");
        }
    }
}
