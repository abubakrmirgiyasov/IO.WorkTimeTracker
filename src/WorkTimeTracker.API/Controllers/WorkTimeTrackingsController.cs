using Microsoft.AspNetCore.Mvc;

namespace WorkTimeTracker.API.Controllers;
public class WorkTimeTrackingsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
