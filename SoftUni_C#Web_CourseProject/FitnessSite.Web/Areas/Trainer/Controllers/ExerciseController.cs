namespace FitnessSite.Web.Areas.Trainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Intarfaces;
    using ViewModels.TypeExercise;
    using ViewModels.Exercise;
    using static Common.NotificationMessagesConstants;

    public class ExerciseController : BaseTrainerController
    {
        private readonly IExerciseService exerciseService;
        private readonly ITypeExerciseService typeExerciseService;

        public ExerciseController(IExerciseService exerciseService,
                                  ITypeExerciseService typeExerciseService)
        {
            this.exerciseService = exerciseService;
            this.typeExerciseService = typeExerciseService;
        }

        public async Task<IActionResult> All()
        {
           IEnumerable<TypeExerciseViewModelAllExrcises> allExercises =
                await exerciseService.AllExerciseWithoutUserAsync();

            return View(allExercises);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            bool isExerciseExist = await exerciseService.IsExersiceExistById(id);
            if (!isExerciseExist)
            {
                TempData[ErrorMessage] = 
                    "This exercise does not exist. Please select existing one";
                return RedirectToAction("Index","Home");
            }

            EditGlobalExerciseViewModel model = 
                await exerciseService.GetGlobalExerciseToEditAsync(id.ToString());

            model.AllTypes = await typeExerciseService.GetTypesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditGlobalExerciseViewModel model,string id)
        {

        }

    }
}
