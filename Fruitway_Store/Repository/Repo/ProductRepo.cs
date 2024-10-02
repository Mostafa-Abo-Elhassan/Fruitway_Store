using Fruitway_Store.Data;
using Fruitway_Store.Models.Entities;
using Fruitway_Store.Repository.IRepo;

namespace Fruitway_Store.Repository.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbcontext dbcontext;

        public ProductRepo(ApplicationDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return dbcontext.Products;
        }

        public Product? GetProductDetail(int Id)
        {
            return dbcontext.Products.FirstOrDefault(e=>e.Id==Id);
        }

        public IEnumerable<Product> GetTrandingProducts()
        {
            return dbcontext.Products.Where(e =>e.IsTrandingProduct);
        }
    }
}
