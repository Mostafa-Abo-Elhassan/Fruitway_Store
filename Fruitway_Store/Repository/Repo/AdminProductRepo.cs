using Fruitway_Store.Data;
using Fruitway_Store.Models.Entities;
using Fruitway_Store.Models.ViewModels;
using Fruitway_Store.Repository.IRepo;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Fruitway_Store.Repository.Repo
{
	public class AdminProductRepo : IAdminProduct
	{
		private readonly ApplicationDbcontext dbcontext;

		public AdminProductRepo(ApplicationDbcontext dbcontext)
        {
			this.dbcontext = dbcontext;
		}
        public Product AddProduct(Product product)
		{
			 dbcontext.Products.Add(product);
			dbcontext.SaveChanges();
			return product;
		}

        public Product? Delete(int id)
        {
            var existing = dbcontext.Products.Find(id);

            if (existing != null)
            {
                dbcontext.Products.Remove(existing); // حذف المنتج الموجود
                dbcontext.SaveChanges(); // حفظ التغييرات
                return existing; // إرجاع المنتج المحذوف
            }

            return null; // إشارة إلى عدم وجود المنتج
        }


        public IEnumerable<Product> GetAllProducts()
		{
			return dbcontext.Products;
		}

		public Product? GetProductById(int Id)
		{
			return dbcontext.Products.Find( Id);
		}

		public Product? GetProductByName(string Name)
		{
			return dbcontext.Products.FirstOrDefault(e => e.Name == Name);
		}

        public Product? UpdateProduct(Product product)
        {
            var existing = dbcontext.Products.FirstOrDefault(e => e.Id == product.Id);

            if (existing != null)
            {
                // تحديث الخصائص
                existing.Name = product.Name;
                existing.Detail = product.Detail;
                existing.Price = product.Price;
                existing.ImageUrl = product.ImageUrl; // إضافة تحديث URL الصورة

                // حفظ التغييرات بشكل متزامن
                dbcontext.SaveChanges();

                return existing;
            }

            return null; // في حالة عدم وجود المنتج
        }


        public object UpdateProduct(AddProductVM uPDATED)
        {
            throw new NotImplementedException();
        }
    }
}
