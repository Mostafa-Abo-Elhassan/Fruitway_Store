using Microsoft.AspNetCore.Mvc;

namespace Fruitway_Store.Controllers
{
    public class Users : Controller
    {
        public IActionResult User()
        {
            return View();
        }
    }
}
