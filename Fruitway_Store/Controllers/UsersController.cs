using Fruitway_Store.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fruitway_Store.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult User()
        {
         
                return View();
           
        }
        [HttpPost]
        public  async Task <IActionResult> user(EditUserVM userVM)
        {
            var user = await userManager.FindByNameAsync(userVM.UserName);
            if (user != null)
            {
                bool result = await userManager.CheckPasswordAsync(user, userVM.Password);
                if (result == true)
                {
                    user.Email = userVM.NEWEmail;
                    user.UserName = userVM.NEWUserName;

                    // Hash and assign password
                    var passwordHasher = new PasswordHasher<IdentityUser>();
                    user.PasswordHash = passwordHasher.HashPassword(user, userVM.NEWPassword);                 
                    await userManager.UpdateAsync(user);
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("User", user);
                }
                return RedirectToAction("User", user);
            }
            return RedirectToAction("User", user);
        }


        [HttpGet]
        public IActionResult DeleteAccount()
        {

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> DeleteAccount (EditUserVM userVM)
        {
            var user = await userManager.FindByNameAsync(userVM.UserName);



            if (user != null)
            {

                bool result = await userManager.CheckPasswordAsync(user, userVM.Password);
                if (result == true)
                {

                    await userManager.DeleteAsync(user);
                    return RedirectToAction("Register", "Account");

                }
                return RedirectToAction("DeleteAccount", userVM);
            }
            return RedirectToAction("DeleteAccount", userVM);
        }
    }
}
