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
        public async Task<IActionResult> Edit(string id)
        {
            bool isExerciseExist = await exerciseService.IsExersiceExistById(id);
            if (!isExerciseExist)
            {
                TempData[ErrorMessage] = 
                    "This exercise does not exist. Please select existing one";
                return RedirectToAction("Index","Home");
            }

            EditGlobalExerciseViewModel model = 
                await exerciseService.GetGlobalExerciseToEditAsync(id);

            model.AllTypes = await typeExerciseService.GetTypesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditGlobalExerciseViewModel model,string id)
        {
            if (!ModelState.IsValid)
            {
                model.AllTypes = await typeExerciseService.GetTypesAsync();
                return View(model);
            }

            bool isTypeExist = await typeExerciseService.IsTypeExistAsync(model.TypeId);
            if (!isTypeExist)
            {
                model.AllTypes = await typeExerciseService.GetTypesAsync();
                ModelState.AddModelError(nameof(model.TypeId),
                    "Selected board does not exist!");
            }

            string exerciseName = 
                await exerciseService.GetExerciseNameByIdAsync(id.ToString());
            try
            {
                await exerciseService.EditGlobalExerciseAsync(id, model);
                TempData[SuccessMessage] =
                    $"You successfully edit {exerciseName}";
                return RedirectToAction("Index","Home");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

                return this.RedirectToAction("Index", "Home");
            }
        }

    }
}
