namespace FitnessSite.Web.Areas.Trainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Intarfaces;
    using ViewModels.TypeExercise;

    public class ExerciseController : BaseTrainerController
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        public async Task<IActionResult> All()
        {
           IEnumerable<TypeExerciseViewModel> allExercises =
                await exerciseService.AllExerciseWithoutUserAsync();

            return View(allExercises);
        }
    }
}
