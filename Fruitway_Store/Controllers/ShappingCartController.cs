using Fruitway_Store.Data;
using Fruitway_Store.Models.Entities;
using Fruitway_Store.Repository.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fruitway_Store.Controllers
{
    [Authorize]
    public class ShappingCartController : Controller
    {
        private readonly ApplicationDbcontext _context;

        private readonly IshappingCart shoppingCartRepository;
        private readonly IProductRepo product;

        public ShappingCartController(IshappingCart shoppingCartRepository, ApplicationDbcontext dbcontext, IProductRepo product)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.product = product;
        }
        public IActionResult Index()
        {
            var items = shoppingCartRepository.GetCartItems();
            shoppingCartRepository.CartItems = items;

            return View(items);
        }





        [HttpPost]
        public RedirectToActionResult AddToshoppingCart(int pId)
        {
            var produc = product.GetAllProducts().FirstOrDefault(s => s.Id == pId);
            if (produc != null)
            {
                shoppingCartRepository.AddToCart(produc);
                int cartcount = shoppingCartRepository.GetCartItems().Count();
                HttpContext.Session.SetInt32("cartcount", cartcount);

            }
            return RedirectToAction("Index", "ShappingCart");
        }

        [HttpPost]
        public RedirectToActionResult RemoveFromCart(int pId)
        {

            var produc = product.GetAllProducts().FirstOrDefault(s => s.Id == pId);
            if (produc != null)
            {
                shoppingCartRepository.RemoveFromCart(produc);
                int cartcount = shoppingCartRepository.GetCartItems().Count();
                HttpContext.Session.SetInt32("cartcount", cartcount);
            }
            return RedirectToAction("Index", "ShappingCart");
        }

        [HttpPost]
        public IActionResult UpdateCart(int id, int qty)
        {
            shoppingCartRepository.UpdateCart(id, qty);

            return RedirectToAction("Index", "ShappingCart");
        }


        [HttpPost]
        public IActionResult ClearCart()
        {
            shoppingCartRepository.ClearCart();
            int cartcount = shoppingCartRepository.GetCartItems().Count();
            HttpContext.Session.SetInt32("cartcount", cartcount);
            return RedirectToAction("Index", "ShappingCart");

        }
    }
}
