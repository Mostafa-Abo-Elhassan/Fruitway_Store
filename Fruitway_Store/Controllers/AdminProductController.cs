using Azure;
using Fruitway_Store.Data;
using Fruitway_Store.Models.Entities;
using Fruitway_Store.Models.ViewModels;
using Fruitway_Store.Repository.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fruitway_Store.Controllers
{
    [Authorize(Roles = "Admin,Super_Admin")]
    public class AdminProductController : Controller
	{
		private readonly IAdminProduct adminProduct;
        private readonly ApplicationDbcontext dbcontext;

        public AdminProductController(IAdminProduct adminProduct , ApplicationDbcontext dbcontext)
        {
			this.adminProduct = adminProduct;
            this.dbcontext = dbcontext;
        }

        public IActionResult GeAllProducts()
		{
			var all = adminProduct.GetAllProducts();
            var count = all.Count();
            ViewBag.count = count;
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
            var existing = dbcontext.Products.FirstOrDefault(e => e.Id == productVM.Id);    
            if (existing != null)
            {        
                existing.Name = productVM.Name;
                existing.Detail = productVM.Detail;
                existing.Price = productVM.Price;
                existing.ImageUrl = productVM.ImageUrl;                
                dbcontext.SaveChanges();

                return RedirectToAction("Edit", new { id = productVM.Id });
            }
            return RedirectToAction("Edit", new { id = productVM.Id });
          
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            // استدعاء دالة الحذف من خدمة إدارة المنتجات باستخدام المعرف
            var existing = dbcontext.Products.Find(Id);

            if (existing != null)
            {
                dbcontext.Products.Remove(existing); // حذف المنتج الموجود
                dbcontext.SaveChanges(); // حفظ التغييرات
                return RedirectToAction("GeAllProducts", "AdminProduct"); // إعادة التوجيه بعد الحذف

            }
            return RedirectToAction("GeAllProducts");

            // تأكد من أن لديك طريقة Delete في adminProduct


        }


        //[HttpPost]
        //public IActionResult Delete2(int Id)
        //{
        //    استدعاء دالة الحذف من خدمة إدارة المنتجات باستخدام المعرف
        //   var existing = dbcontext.Products.Find(Id);

        //    if (existing != null)
        //    {
        //        dbcontext.Products.Remove(existing); // حذف المنتج الموجود
        //        dbcontext.SaveChanges(); // حفظ التغييرات
        //        return RedirectToAction("GeAllProducts"); // إعادة التوجيه بعد الحذف

        //    }
        //    return RedirectToAction("GeAllProducts", "Home");

        //    //تأكد من أن لديك طريقة Delete في adminProduct
 




        //}









    }
}
