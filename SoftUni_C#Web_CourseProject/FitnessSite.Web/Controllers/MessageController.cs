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
        private readonly IUserService userService;

        public MessageController(ITrainerService trainerService,
                                 IMessageService messageService,
                                 IUserService userService)
        {
            this.trainerService = trainerService;
            this.messageService = messageService;
            this.userService = userService;

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
                await userService.IsUserHaveTrainerAsync(User.GetById().ToString());
            if (isUserHaveTrainer)
            {
                bool isUserHaveThisTrainer =
                    await userService.IsUserHaveThisTrainerAsync(User.GetById(), id);
                if (!isUserHaveThisTrainer)
                {
                    TempData[WarningMessage] =
                        "You allready have trainer. You can have only one";
                    return RedirectToAction("MyTrainer", "Trainer");
                }
            }

            return View(new SendMessageViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageViewModel message, string id)
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
               await userService.IsUserHaveThisTrainerAsync(User.GetById(), id);
            if (isUserHaveTrainer)
            {
                bool isUserHaveThisTrainer =
                    await userService.IsUserHaveThisTrainerAsync(User.GetById(), id);
                if (!isUserHaveThisTrainer)
                {
                    TempData[WarningMessage] =
                        "You already have trainer. You can have only one";
                    return RedirectToAction("All", "Trainer");
                }

            }

            string senderId = User.GetById();

            try
            {
                await messageService.
                    SendMessageAsync(senderId, id, message);
                TempData[SuccessMessage] = "You successfully send a message";
                return RedirectToAction("All", "Trainer");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        public async Task<IActionResult> All()
        {
            string userId = User.GetById();

            ICollection<AllMessageViewModel>? messages =
                await messageService.MyMessagesAsync(userId);

            return View(messages);
        }

        public async Task<IActionResult> ShowDetails(string id)
        {
            bool isMessageExist = await messageService.IsMessageExistAsync(id);
            if (!isMessageExist)
            {
                return MessageDoNotExist();
            }

            ShowDetailsMessageViewModel message =
                await messageService.GetMessageDetailsAsync(id);

            return View(message);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            bool isMessageExist = await messageService.IsMessageExistAsync(id);
            if (!isMessageExist)
            {
                return MessageDoNotExist();
            }

            try
            {
                await messageService.DeleteMessageAsync(id);
                TempData[SuccessMessage] =
                    "You successfully delete this message";
                return RedirectToAction("All");
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

        private IActionResult MessageDoNotExist()
        {
            TempData[ErrorMessage] =
                    "This message does not exist. Please select existing one";
            return RedirectToAction("All");
        }
    }
}
