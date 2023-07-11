namespace FitnessSite.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Intarfaces;
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
            string? userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                var allTypesWhithoutUser = 
                    await exerciseService.AllExerciseWithoutUserAsync();
                return View(allTypesWhithoutUser);
            }

            var allTypesWhitUser = await exerciseService.AllExerciseWithUserAsync(userId);
            return View(allTypesWhitUser);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isExerciceExist = await exerciseService.IsExersiceExistById(id);
            bool isExerciseAddedToThisTraining = await exerciseService.IsExerciseExistInThisTrainingAsync(id,userId);
            
            if (!isExerciceExist)
            {
                ModelState.AddModelError((nameof(id)), "Selected exercise does not exist.");
                return RedirectToAction("All");
            }

            if (isExerciseAddedToThisTraining)
            {
                TempData[WarningMessage] = "You already have this exercise to your training";
                return RedirectToAction("Mine","Training");
            }

            await exerciseService.AddExerciseAsync(id, userId);
            return RedirectToAction("All");
        }
    }
}
