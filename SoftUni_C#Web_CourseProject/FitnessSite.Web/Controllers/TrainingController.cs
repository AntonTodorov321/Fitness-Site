namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TrainingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
