namespace FitnessSite.Web.Areas.Trainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Infastructure.Extensions;
    using ViewModels.Message;
    using Services.Intarfaces;
    using static Common.NotificationMessagesConstants;

    public class MessageController : BaseTrainerController
    {
        private readonly IMessageService messageService;
        private readonly ITrainerService trainerService;
        private readonly IUserService userService;

        public MessageController(IMessageService messageService,
                                 ITrainerService trainerService,
                                 IUserService userService)
        {
            this.messageService = messageService;
            this.trainerService = trainerService;
            this.userService = userService;

        }


        public async Task<IActionResult> All()
        {
            string userId = User.GetById();

            ICollection<AllMessageViewModel>? messages =
                await messageService.MyMessagesAsTrainerAsync(userId);

            return View(messages);
        }

        public async Task<IActionResult> ShowDetails(string id)
        {
            bool isMessageExist = await messageService.IsMessageExistAsync(id);
            if (!isMessageExist)
            {
                return MessageDontExist();
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
                return MessageDontExist();
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

        [HttpPost]
        public async Task<IActionResult> Accept(string id)
        {
            string userTrainerId = User.GetById();

            bool isTrainerHaveThisUser =
                await trainerService.IsTrainerHaveThisUserAsync(userTrainerId, id);

            if (isTrainerHaveThisUser)
            {
                TempData[WarningMessage] =
                    "You are already trainer to this user";
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await messageService.AssigningUserToTrainerAsync(id, userTrainerId);
                TempData[SuccessMessage] =
                    "You successfully assign this user";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage(string id)
        {
            bool isUserExist =
                await userService.IsUserExistAsync(id);
            if (!isUserExist)
            {
                TempData[WarningMessage] =
                    "This user does not exist! Pleace select existing one";
                return RedirectToAction("Index", "Home");
            }

            return View(new SendMessageViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageViewModel message, string id)
        {
            bool isUserExist =
               await userService.IsUserExistAsync(id);
            if (!isUserExist)
            {
                TempData[WarningMessage] =
                    "This user does not exist! Pleace select existing one";
                return RedirectToAction("Index", "Home");
            }

            string userId = User.GetById();
            string trainerId = 
                await trainerService.GetTrainerIdByApplicationUserIdAsync(userId);

            try
            {
                await messageService.
                    SendMessageAsync(trainerId, id, message);
                TempData[SuccessMessage] = "You successfully send a message";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private IActionResult MessageDontExist()
        {
            TempData[ErrorMessage] =
                    "This message does not exist. Please select existing one";
            return RedirectToAction("All");
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return this.RedirectToAction("Index", "Home");
        }
    }
}
