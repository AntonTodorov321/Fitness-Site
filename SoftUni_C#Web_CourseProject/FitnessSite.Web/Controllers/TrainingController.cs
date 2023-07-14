namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Services.Intarfaces;
    using Infastructure.Extensions;
    using FitnessSite.Web.ViewModels.Training;

    [Authorize]
    public class TrainingController : Controller
    {
        private readonly ITrainingService trainingServise;

        public TrainingController(ITrainingService trainingService)
        {
            this.trainingServise = trainingService;
        }

        public async Task<IActionResult> Mine()
        {
            string userId = User.GetById();

            TrainingViewModel? myTraining = await trainingServise.GetTrainingAsync(userId);

            return View(myTraining);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            string userId = User.GetById();
            await trainingServise.RemoveExerciseFromTraining(id,userId);

            return RedirectToAction("Mine");
        }

       
    }
}
