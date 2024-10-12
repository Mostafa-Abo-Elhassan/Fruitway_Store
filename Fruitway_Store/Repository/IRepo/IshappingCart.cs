using Fruitway_Store.Models.Entities;
using Fruitway_Store.Repository.IRepo;

namespace Fruitway_Store.Repository.IRepo
{
    public interface IshappingCart
    {
        void AddToCart(Product product); // إضافة منتج إلى العربة
        //int UpdateCart(int id, int qty); // تحديث كمية المنتج في العربة
         int  RemoveFromCart(Product product); // إزالة المنتج من العربة
        List<ShappingCart> GetCartItems(); // استرجاع العناصر في العربة
        decimal GetCartTotal(); // حساب المجموع الكلي للعربة
        void ClearCart(); // مسح جميع العناصر من العربة

        public List<ShappingCart>? CartItems { get; set; }
        void UpdateCart(int id, int qty);











    }
}








//void AddToCart(Product product, int qty, string shoppingCartId); // إضافة منتج إلى العربة
//void UpdateCart(int id, int qty); // تحديث كمية المنتج في العربة
//void RemoveFromCart(int id); // إزالة المنتج من العربة
//List<shappingCart> GetCartItems(string shoppingCartId); // استرجاع العناصر في العربة
//decimal GetCartTotal(string shoppingCartId); // حساب المجموع الكلي للعربة
//void ClearCart(string shoppingCartId); // مسح جميع العناصر من العربة
