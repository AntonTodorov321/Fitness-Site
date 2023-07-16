namespace FitnessSite.Web.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Intarfaces;
    using Infastructure.Extensions;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            string? userId = this.User.GetById();

            if (userId == null)
            {
                var allTypesWhithoutUser = 
                    await exerciseService.AllExerciseWithoutUserAsync();
                return View(allTypesWhithoutUser);

            }

            try
            {
                var allTypesWhitUser = await exerciseService.AllExerciseWithUserAsync(userId);
                return View(allTypesWhitUser);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            TempData[InformationMessage] = "Please use the button";
            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Add(Guid id)
        {
            string userId = User.GetById();

            bool isExerciceExist = await exerciseService.IsExersiceExistById(id);
            if (!isExerciceExist)
            {
               TempData[ErrorMessage] = "Selected exercise does not exist.";
                return RedirectToAction("All");
            }

            bool isExerciseAddedToThisTraining = await exerciseService.IsExerciseExistInThisTrainingAsync(id,userId);
            if (isExerciseAddedToThisTraining)
            {
                TempData[WarningMessage] = "You already have this exercise to your training";
                return RedirectToAction("Mine","Training");
            }

            try
            {
                await exerciseService.AddExerciseAsync(id, userId);
                TempData[SuccessMessage] =
                    $"You successfully add {await exerciseService.GetExerciseNameByIdAsync(id)} exercise.";
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
    }
}
