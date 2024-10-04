using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fruitway_Store.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> UserManager;
		public AccountController(UserManager<IdentityUser> userManager)
        {
			this.UserManager = userManager;
        }

		#region login

		[HttpGet]
		public IActionResult Login()
		{

			return View();
		}

		[HttpPost]
		public IActionResult login()
		{
			return View("Login", "Account");
		}

		#endregion


		#region register


		[HttpGet]
		public IActionResult Register()
		{

			return View();
		}

		[HttpPost]
		public IActionResult register()
		{
			return View("Register", "Account");
		}




		#endregion



	}
}
