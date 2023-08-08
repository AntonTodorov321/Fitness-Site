namespace FitnessSite.Web.Areas.Trainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseTrainerController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
