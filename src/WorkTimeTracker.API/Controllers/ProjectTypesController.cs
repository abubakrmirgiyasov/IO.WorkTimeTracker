using Microsoft.AspNetCore.Mvc;

namespace WorkTimeTracker.API.Controllers;
public class ProjectTypesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
