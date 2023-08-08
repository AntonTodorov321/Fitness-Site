namespace FitnessSite.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using Models;
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}