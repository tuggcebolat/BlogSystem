using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
