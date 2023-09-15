using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using BlogSystem.Entities;
using BlogSystem.Models;
using NETCore.Encrypt.Extensions;
using System.Security.Claims;

namespace BlogSystem.Controllers
{
	public class AccountController : Controller
	{
        private readonly DatabaseContext _databaseContext;
		private readonly IConfiguration _configuration;

        public AccountController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
        public IActionResult Login(LoginViewsModel model)
        {
			if(ModelState.IsValid)
			{
                string md5Salt = _configuration.GetValue<string>("AppSettings: MD5Salt");
                string saltedPassword = model.Password + md5Salt;
                string hashedPassword = saltedPassword.MD5();
				User user = _databaseContext.Users.SingleOrDefault(x => x.Username.ToLower() == model.Username.ToLower() && x.Password==hashedPassword);
				if(user != null)
				{
					if (user.Locked)
					{
						ModelState.AddModelError(nameof(model.Username), $"{model.Username} is locked");
						return View(model);
					}
					//cookies
					List<Claim> claims = new List<Claim>();
					claims.Add(new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()));
					claims.Add(new Claim(ClaimTypes.Name,user.FullName.ToString()));
					claims.Add(new Claim("Username",user.Username));
					ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
					ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
					HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
					RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Username or password is incorrect.");
				}


            }
            return View(model);
        }
        public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
			if (ModelState.IsValid)
			{
				if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
				{
					ModelState.AddModelError(nameof(model.Username), "Username is already exits.");
				    View(model); //kullanıcı var daha fazla ilerleme 
				}
				string md5Salt = _configuration.GetValue<string>("AppSettings: MD5Salt");
				string saltedPassword= model.Password + md5Salt;
				string hashedPassword = saltedPassword.MD5();

                User user = new () 
				{
					Username = model.Username,
					Password = hashedPassword

				};
			   _databaseContext.Users.Add(user);
				int affectedRowCount  = _databaseContext.SaveChanges();
				if(affectedRowCount == 0)
				{
					ModelState.AddModelError("", "User can not be added.");

				}
				else
				{
					return RedirectToAction(nameof(Login));
				}
			}
            return View(model);
        }
        public IActionResult Profile()
		{
			return View();
		}
	}

}
