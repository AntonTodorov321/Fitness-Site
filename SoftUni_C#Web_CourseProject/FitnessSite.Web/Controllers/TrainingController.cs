namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TrainingController : Controller
    {
        public async Task<IActionResult> Mine()
        {
            return View();
        }
    }
}
