namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Services.Intarfaces;
    using Infastructure.Extensions;

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

            var myTraining = await trainingServise.GetTrainingAsync(userId);
            return View(myTraining);
        }
    }
}
