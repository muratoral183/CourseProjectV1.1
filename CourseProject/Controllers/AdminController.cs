using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
