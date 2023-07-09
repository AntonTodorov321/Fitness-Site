namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components.Web;
    using Microsoft.AspNetCore.Mvc;

    using Services.Intarfaces;
    using System.Security.Claims;

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
            
            if (!isExerciceExist)
            {
                
            }

            await exerciseService.AddExerciseAsync(id, userId);
            return RedirectToAction("All");
        }
    }
}
