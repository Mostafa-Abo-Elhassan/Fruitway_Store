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


        public IEnumerable<Product> GetAllProducts()
		{
			return dbcontext.Products;
		}

		public Product? GetProductById(int Id)
		{
			return dbcontext.Products.FirstOrDefault(e => e.Id == Id);
        }

		public Product? GetProductByName(string Name)
		{
			return dbcontext.Products.FirstOrDefault(e => e.Name == Name);
		}

       


      
    }
}
