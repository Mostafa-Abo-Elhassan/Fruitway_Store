using Fruitway_Store.Models.Entities;
using Fruitway_Store.Models.ViewModels;

namespace Fruitway_Store.Repository.IRepo
{
	public interface IAdminProduct
	{
		IEnumerable<Product> GetAllProducts();
		Product? GetProductById(int Id);
		Product? GetProductByName(string Name);

		Product AddProduct(Product product);
		Product? UpdateProduct(Product product);

		Product? Delete(int Id);
        object UpdateProduct(AddProductVM uPDATED);
    }
}
