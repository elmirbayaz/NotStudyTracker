using Microsoft.AspNetCore.Mvc;
using StudyTracker.Models;
using StudyTracker.ViewModelBuilders;
using System.Diagnostics;

namespace StudyTracker.Controllers
{
    public class HomeController : Controller
    {
            private readonly ILogger<HomeController> _logger;

            public HomeController(ILogger<HomeController> logger)
            {
                _logger = logger;
            }

            public IActionResult Index()
            {
                return RedirectToAction(nameof(CoursesController.Index), "Courses");
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

    }

