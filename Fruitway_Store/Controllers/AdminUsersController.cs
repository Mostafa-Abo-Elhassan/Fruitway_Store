using Fruitway_Store.Models.ViewModels;
using Fruitway_Store.Repository.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fruitway_Store.Controllers
{
    [Authorize(Roles = "Admin,Super_Admin")]
    public class AdminUsers : Controller
    {
        private readonly Iuser iuser;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminUsers(Iuser iuser, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.iuser = iuser;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            var users = await iuser.GetALLUsers();
            var count = users.Count();
            var UserSelecting = new USERS();
            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault() ?? "No Role";

                UserSelecting.Users.Add(new UserVM
                {
                    Id = Guid.Parse(user.Id),
                    UserName = user.UserName,
                    Email = user.Email,
                    RoleName = roleName,
                    count = count

                }
                );

                ViewBag.count = count;
            }
            return View(UserSelecting); // إرجاع الـ View مع البيانات

        }


        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var USER = await userManager.FindByIdAsync(Id.ToString());
            if (USER != null)
            {
                var user = new AdminEditUserVM()
                {
                    Id = Guid.Parse(USER.Id),
                    UserName = USER.UserName,
                    Email = USER.Email,
                    
                    

                };

                return View(user);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> SaveEdit(AdminEditUserVM editUserVM)
        {
            var USER = await userManager.FindByIdAsync(editUserVM.Id.ToString());
            if (USER != null)
            {


                USER.Email = editUserVM.NEWEmail;
                USER.UserName = editUserVM.NEWUserName;

                // Hash and assign password
                var passwordHasher = new PasswordHasher<IdentityUser>();

                USER.PasswordHash = passwordHasher.HashPassword(USER, editUserVM.NEWPassword);
                await userManager.UpdateAsync(USER);

                return RedirectToAction("Edit","AdminUsers");

               

            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var USER = await userManager.FindByIdAsync(id.ToString());
            if (USER != null)
            {
                var identityResult = await userManager.DeleteAsync(USER);
                return RedirectToAction("AllUsers", "AdminUsers");
            }
            return View();
        }


        [HttpGet]
        public IActionResult AddUser()
        {

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(USERS model)
        {

            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var identityResult = await userManager.CreateAsync(user, model.Password);
            if (identityResult is not null)
            {

                if (identityResult.Succeeded)
                {


                    var roles = new List<string> { "User" };
                    if (model.checkAdmin)
                    {
                        roles.Add("Admin");

                    }

                    identityResult = await userManager.AddToRolesAsync(user, roles);
                    if (identityResult is not null && identityResult.Succeeded)
                    {
                        return RedirectToAction("AllUsers", "AdminUsers");
                    }



                }



            }


            return RedirectToAction("AddUser", "AdminUsers");
        }



    }
}
