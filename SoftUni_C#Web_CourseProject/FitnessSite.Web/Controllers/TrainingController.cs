namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Services.Intarfaces;
    using Infastructure.Extensions;
    using ViewModels.Training;
    using static Common.NotificationMessagesConstants;
    using ViewModels.Exercise;

    [Authorize]
    public class TrainingController : Controller
    {
        private readonly ITrainingService trainingServise;
        private readonly IExerciseService exerciseServise;

        public TrainingController(ITrainingService trainingService, IExerciseService exerciseServise)
        {
            this.trainingServise = trainingService;
            this.exerciseServise = exerciseServise;

        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            string userId = User.GetById();

            TrainingViewModel? myTraining = await trainingServise.GetTrainingAsync(userId);

            return View(myTraining);
        }

        [HttpGet]
        public IActionResult Remove()
        {
            TempData[InformationMessage] = "Please use the button";
            return RedirectToAction("Mine");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string id)
        {
            bool isExerciseExist = await exerciseServise.IsExersiceExistByIdAsync(id);

            if (!isExerciseExist)
            {
                TempData[ErrorMessage] =
                    "Exercise does not exist. Please select another exercise";
                return RedirectToAction("Mine");
            }

            string userId = User.GetById();
            bool isExerciseInTraining = await trainingServise.IsExerciseExistInTrainingAsync(userId, id);
            if (!isExerciseInTraining)
            {
                TempData[WarningMessage] =
                    "Exercise does not exist in this training. Please select exercise from this training";
                return RedirectToAction("Mine");
            }

            try
            {
                string exerciseName = await exerciseServise.GetExerciseNameByIdAsync(id);
                await trainingServise.RemoveExerciseFromTrainingAsync(id, userId);
                TempData[WarningMessage] =
                    $"You successfully remove {exerciseName} exercise";
                return RedirectToAction("Mine");

            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool isExerciseExist = await exerciseServise.IsExersiceExistByIdAsync(id);
            if (!isExerciseExist)
            {
                TempData[ErrorMessage] =
                    "Selected exercise does not exist. Please select existing exercise";
                return RedirectToAction("Mine");
            }

            string userId = User.GetById();
            bool isExerciseInTraining =
                await trainingServise.IsExerciseExistInTrainingAsync(userId, id);

            if (!isExerciseInTraining)
            {
                TempData[WarningMessage] =
                    "Exercise does not exist in this training. Please select exercise from this training";
                return RedirectToAction("Mine");
            }

            GetExerciseToEditViewModel viewModel = 
                await exerciseServise.GetExerciseToEditAsync(id);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditExerciseViewModel model)
        {
            bool isExerciseExist =
                await exerciseServise.IsExersiceExistByIdAsync(id);
            if (!isExerciseExist)
            {
                TempData[ErrorMessage] = 
                    "Selected exercise does not exist. Please select existing exercise";
                return RedirectToAction("Mine");
            }

            string userId = User.GetById();
            bool isExerciseInTraining =
                await trainingServise.IsExerciseExistInTrainingAsync(userId, id);

            if (!isExerciseInTraining)
            {
                TempData[WarningMessage] =
                    "Exercise does not exist in this training. Please select exercise from this training";
                return RedirectToAction("Mine");
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please fild the labels corecctly");
                return RedirectToAction("Edit");
            }

            string exerciseName = await exerciseServise.GetExerciseNameByIdAsync(id);
            try
            {
                await exerciseServise.EditExerciseAsync(id, model, userId);
                TempData[SuccessMessage] = 
                    $"You successfully edit {exerciseName} exercise";
                return RedirectToAction("Mine");
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
