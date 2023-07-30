using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Controllers
{
    public class BlogPostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
