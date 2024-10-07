using Fruitway_Store.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fruitway_Store.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.UserManager = userManager;
            this.signInManager = signInManager;
        }

        #region login

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(LoginVM login)
        {
            var user = await UserManager.FindByNameAsync(login.UserName);

            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    bool result = await UserManager.CheckPasswordAsync(user, login.Password);
                    if (result == true)
                    {
                        await signInManager.SignInAsync(user, login.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Invalid user name or password.");
                }

                ModelState.AddModelError("", "Invalid email or password.");

            }
            return RedirectToAction("Register", "Account");
        }

        #endregion


        #region register


        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> register(RegisterVM model)
        {
            //var user = new IdentityUser
            //{
            //	UserName = model.UserName,
            //	Email= model.Email
            //};
            //IdentityResult result = await UserManager.CreateAsync(user, model.Password);
            //         if (result.Succeeded)
            //         {
            //	await UserManager.AddToRoleAsync(user, "User");

            //	return RedirectToAction("Login", "Account");

            //         }
            //         return RedirectToAction("Register", "Account");




            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var userrole = await UserManager.AddToRoleAsync(user, "User");
                    if (userrole.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
                        return RedirectToAction("Login", "Account");
                    }
                    //return RedirectToAction("Index", "Home");
                    return RedirectToAction("Register");
                }

                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return RedirectToAction("Register", "Account",model);



        }


        #endregion

        #region logout

        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        #endregion

    }
}
