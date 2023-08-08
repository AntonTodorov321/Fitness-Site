namespace FitnessSite.Web.Areas.Trainer.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.GeneralApplicationConstants;

    [Area(TrainerAreaName)]
    [Authorize(Roles = TrainerRoleName)]
    public class BaseTrainerController : Controller
    {

    }
}
