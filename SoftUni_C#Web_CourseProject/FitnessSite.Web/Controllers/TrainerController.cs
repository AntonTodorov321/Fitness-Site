namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Trainer;
    using Services.Intarfaces;
    using static Common.NotificationMessagesConstants;
    using Infastructure.Extensions;

    [Authorize]
    public class TrainerController : Controller
    {
        private readonly ITrainerService trainerService;
        private readonly IMessageService messageService;
        private readonly IUserService userService;

        public TrainerController(ITrainerService trainerService,
                                 IMessageService messageService,
                                 IUserService userService)
        {
            this.trainerService = trainerService;
            this.messageService = messageService;
            this.userService = userService;

        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            try
            {
                List<AllTrainerViewModel> allTrainers = await
                    trainerService.GetAllTrainersAsync();

                return View(allTrainers);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isTrainerExist =
                await trainerService.IsTrainerExesitAsync(id);
            if (!isTrainerExist)
            {
                TempData[WarningMessage] = 
                    "This trainer does not exist! Pleace select existing one";
                return RedirectToAction("All");
            }

            try
            {
                DetailsTrainerViewModel trainer
                    = await trainerService.GetTrainerDetailsAsync(id);
                return View(trainer);

            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        public async Task<IActionResult> MyTrainer()
        {
            bool isUserHaveTrainer =
                await userService.IsUserHaveTrainerAsync(User.GetById());
            if (!isUserHaveTrainer)
            {
                TempData[WarningMessage] =
                    "You dont have trainer yet!";

                return RedirectToAction("All", "Trainer");
            }

            string trainerId = 
                await trainerService.GetTrainerIdByUserId(User.GetById());
            DetailsTrainerViewModel model =
                await trainerService.GetTrainerDetailsAsync(trainerId);

            return View(model);
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return this.RedirectToAction("Index", "Home");
        }
    }

}
