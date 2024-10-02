using Fruitway_Store.Models.Entities;

namespace Fruitway_Store.Repository.IRepo
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetTrandingProducts();
        Product? GetProductDetail(int Id);

    }
}
