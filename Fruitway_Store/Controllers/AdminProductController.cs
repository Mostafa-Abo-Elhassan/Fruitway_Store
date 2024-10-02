using Azure;
using Fruitway_Store.Models.Entities;
using Fruitway_Store.Models.ViewModels;
using Fruitway_Store.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fruitway_Store.Controllers
{
	public class AdminProductController : Controller
	{
		private readonly IAdminProduct adminProduct;

		public AdminProductController(IAdminProduct adminProduct)
        {
			this.adminProduct = adminProduct;
		}
        public IActionResult GeAllProducts()
		{
			var all = adminProduct.GetAllProducts();
			return View(all);
		}

		[HttpGet]
        public IActionResult ADD()
        {
            
            return View();
        }
		[HttpPost]
		public IActionResult SaveAdd(AddProductVM productVM)
		{
			Product tag = new Product
			{
				Name = productVM.Name,
				Detail= productVM.Detail,
				Price = productVM.Price,
				ImageUrl = productVM.ImageUrl
			};
			adminProduct.AddProduct(tag);
			
			return RedirectToAction("GeAllProducts");
		}


		[HttpGet]
		public IActionResult Edit(int id)
		{
			var iff = adminProduct.GetProductById(id);
            if (iff != null)
            {
                var Evm = new EditProduct
                {

					Id = iff.Id,
                    Name = iff.Name,
                    Detail = iff.Detail,
                    Price = iff.Price,
                    ImageUrl = iff.ImageUrl


                };
                return View(Evm);
            }
			return NotFound();



          
		}
		[HttpPost]
        
        public IActionResult SaveEdit(EditProduct productVM)
        {
            var product = adminProduct.GetProductById(productVM.Id); // استدعاء الأسلوب المتزامن

            if (product == null)
            {
                return NotFound();
            }

            // تحديث خصائص المنتج
            product.Name = productVM.Name;
            product.Detail = productVM.Detail;
            product.Price = productVM.Price;
            product.ImageUrl = productVM.ImageUrl;

            // تحديث المنتج في قاعدة البيانات
            var updatedProduct = adminProduct.UpdateProduct(product); // استدعاء الأسلوب المتزامن

            if (updatedProduct != null)
            {
                return RedirectToAction("GeAllProducts");
            }

            return View("Edit",  productVM ); // إعادة عرض الصفحة في حال الفشل
        }

        [HttpPost]
        public IActionResult Delete(EditProduct productVM)
        {
            // استدعاء دالة الحذف من خدمة إدارة المنتجات باستخدام المعرف
             adminProduct.Delete(productVM.Id);

                // تأكد من أن لديك طريقة Delete في adminProduct

            return RedirectToAction("GeAllProducts"); // إعادة التوجيه بعد الحذف


        }







    }
}
