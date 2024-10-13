using Fruitway_Store.Models.Entities;
using Fruitway_Store.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace Fruitway_Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepo order;
        private readonly IshappingCart ishapping;

        public OrderController(IOrderRepo order , IshappingCart ishapping)
        {
            this.order = order;
            this.ishapping = ishapping;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult checkout(Order OOrder)
        {
            order.PlaceOrder(OOrder);
            ishapping.ClearCart();
			HttpContext.Session.SetInt32("cartcount", 0);
			return RedirectToAction("completecheckout");
        }
        public IActionResult completecheckout()
        {
            return View();
        }


    }
}
