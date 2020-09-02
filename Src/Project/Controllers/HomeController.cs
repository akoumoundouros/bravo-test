using Microsoft.AspNetCore.Mvc;
using Project.Svc;

namespace Project.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private IDependencyService _dependency;
        public HomeController(IDependencyService dependency)
        {
            _dependency = dependency;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}