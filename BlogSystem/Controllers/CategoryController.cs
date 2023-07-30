using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
