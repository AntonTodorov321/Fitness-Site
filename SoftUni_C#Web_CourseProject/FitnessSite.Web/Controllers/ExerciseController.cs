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
            var allTypes = await exerciseService.AllExerciseAsync();
            return View(allTypes);
        }

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
                
            }

            if (isExerciseAddedToThisTraining)
            {
                TempData[WarningMessage] = "You already have this exercise to your training";
                return RedirectToAction("All");
            }

            await exerciseService.AddExerciseAsync(id, userId);
            return RedirectToAction("All");
        }
    }
}
