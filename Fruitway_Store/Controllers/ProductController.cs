using Fruitway_Store.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace Fruitway_Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo repo;

        public ProductController(IProductRepo repo)
        {
            this.repo = repo;
        }

		public IActionResult GetTrandingProduct()
		{
		
			var GetTrandingProduct = repo.GetTrandingProducts();
			return View(GetTrandingProduct);
		}
		public IActionResult Shop()
        {
			var GetAllProduct = repo.GetAllProducts();
			return View(GetAllProduct);

		}

		public IActionResult Detail(int id)
        {
           var  productdetail = repo.GetProductDetail(id);
            if (productdetail==null)
            {
                return RedirectToAction("NOTFOUND","Home");

            }
            
            
                return View(productdetail);
            

           
        }
    }
}
