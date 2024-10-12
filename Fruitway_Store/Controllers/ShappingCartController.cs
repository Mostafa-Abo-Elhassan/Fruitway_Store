using Fruitway_Store.Data;
using Fruitway_Store.Models.Entities;
using Fruitway_Store.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace Fruitway_Store.Controllers
{
    public class ShappingCartController : Controller
    {
        private readonly ApplicationDbcontext _context;

        private readonly IshappingCart shoppingCartRepository;
        private readonly IProductRepo product;

        public ShappingCartController(IshappingCart shoppingCartRepository, ApplicationDbcontext dbcontext,IProductRepo product)
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
            if (produc!= null)
            {
                shoppingCartRepository.AddToCart(produc);
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
			}
			return RedirectToAction("Index", "ShappingCart");
		}

		[HttpPost]
		public IActionResult UpdateCart(int id, int qty)
		{
			shoppingCartRepository.UpdateCart(id, qty); 
			return RedirectToAction("Index", "ShappingCart"); 
		}

		//[HttpPost]
		//public IActionResult RemoveFromCart(int id)
		//{
		//    _shoppingCartRepository.RemoveFromCart(id); // إزالة المنتج من العربة
		//    return RedirectToAction("Index", "ShappingCart"); // إعادة توجيه إلى الصفحة الرئيسية للعربة
		//}

		//[HttpPost]
		//public IActionResult ClearCart()
		//{
		//    var shoppingCartId = HttpContext.Session.GetString("CartId"); // الحصول على معرف العربة من الجلسة
		//    _shoppingCartRepository.ClearCart(shoppingCartId); // مسح العناصر من العربة
		//    return RedirectToAction("Index", "ShappingCart"); // إعادة توجيه إلى الصفحة الرئيسية للعربة
		//}
	}
}
