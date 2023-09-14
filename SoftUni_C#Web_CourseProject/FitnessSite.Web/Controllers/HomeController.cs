namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using static Common.GeneralApplicationConstants;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole(TrainerRoleName))
            {
                return RedirectToAction("Index", "Home", new { Area = TrainerAreaName });
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400  || statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }
    }
}