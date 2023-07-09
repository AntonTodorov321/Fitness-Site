namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Intarfaces;

    [AllowAnonymous]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        public async Task<IActionResult> All()
        {
            var allTypes = await exerciseService.AllExerciseAsync();
            return View(allTypes);
        }
    }
}
