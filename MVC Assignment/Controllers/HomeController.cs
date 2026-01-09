using Microsoft.AspNetCore.Mvc;
using MVC_Assignment.Filters;

namespace MvcAssignment.Controllers
{
    public class HomeController : Controller
    {
        // GET: /
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to the MVC Assignment";
            return View();
        }

        // GET: /about
        [HttpGet("about")]
        [AboutActionFilter]
        public IActionResult About()
        {
            ViewBag.Message = "About Us";
            return View();
        }
    }
}
