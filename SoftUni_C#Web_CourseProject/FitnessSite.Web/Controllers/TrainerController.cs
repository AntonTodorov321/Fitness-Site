namespace FitnessSite.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class TrainerController : Controller
    {
        [AllowAnonymous]
        public IActionResult All()
        {
            return View();
        }
    }
}
