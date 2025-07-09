using Microsoft.AspNetCore.Mvc;

namespace WorkTimeTracker.API.Controllers;
public class ProjectsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
