namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Services.Intarfaces;
    using Infastructure.Extensions;
    using ViewModels.Training;
    using static Common.NotificationMessagesConstants;
    using FitnessSite.Web.ViewModels.Exercise;

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
        public async Task<IActionResult> Remove(int id)
        {
            bool isExerciseExist = await exerciseServise.IsExersiceExistById(id);

            if (!isExerciseExist)
            {
                TempData[ErrorMessage] =
                    "Exercise does not exist. Please select another exercise";
                return RedirectToAction("Mine");
            }

            string userId = User.GetById();
            bool isExerciseInTraining = await trainingServise.isExerciseExistInTrainingAsync(userId, id);
            if (!isExerciseInTraining)
            {
                TempData[WarningMessage] =
                    "Exercise does not exist in this training. Please select exercise from this training";
                return RedirectToAction("Mine");
            }

            try
            {
                await trainingServise.RemoveExerciseFromTrainingAsync(id, userId);
                TempData[WarningMessage] =
                    $"You successfully remove " +
                    $"{await exerciseServise.GetExerciseNameByIdAsync(id)} exercise";
                return RedirectToAction("Mine");

            }
            catch (Exception)
            { 
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool isExerciseExist = await exerciseServise.IsExersiceExistById(id);
            if (!isExerciseExist)
            {
                TempData[ErrorMessage] = "Selected exercise does not exist. Please select another exercise";
                return RedirectToAction("Mine");
            }

            string userId = User.GetById();
            bool isExerciseInTraining = await trainingServise.isExerciseExistInTrainingAsync(userId, id);

            if (!isExerciseInTraining)
            {
                TempData[WarningMessage] =
                    "Exercise does not exist in this training. Please select exercise from this training";
                return RedirectToAction("Mine");
            }

            EditExerciseViewModel viewModel = await exerciseServise.GetExerciseToEditAsync(id);

            return View(viewModel);
        }
    }
}
