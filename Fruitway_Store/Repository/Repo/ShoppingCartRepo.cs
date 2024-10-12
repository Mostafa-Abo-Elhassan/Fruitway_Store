using Fruitway_Store.Data;
using Fruitway_Store.Models.Entities;
using Fruitway_Store.Repository.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fruitway_Store.Repository.Repo
{
    public class ShoppingCartRepo : IshappingCart
    {
        private readonly ApplicationDbcontext context;
       

        public ShoppingCartRepo(ApplicationDbcontext dbContext)
        {
            context = dbContext;
        }

        public List<ShappingCart>? CartItems { get; set; }
        public string? ShoppingCartIds { get; set; }
        public List<ShappingCart>? ShappingCarts { get; private set; }

        #region session

        public static ShoppingCartRepo GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            ApplicationDbcontext Context = services.GetService<ApplicationDbcontext>()
                    ?? throw new Exception("Error Initializing ApplicationDbContext");

            string cartId = session?.GetString("cartId") ?? Guid.NewGuid().ToString();
            session?.SetString("cartId", cartId);
            return new ShoppingCartRepo(Context) { ShoppingCartIds = cartId };
        }

       

        //public ShoppingCartRepo(ApplicationDbcontext dbContext, IHttpContextAccessor httpContextAccessor)
        //{
        //    context = dbContext;
        //    session = httpContextAccessor.HttpContext?.Session;

        //    ShoppingCartId = session?.GetString("cartId") ?? Guid.NewGuid().ToString();
        //    session?.SetString("cartId", ShoppingCartId);
        //}



        #endregion

        #region addtocart

        public void AddToCart(Product product)
        {
            var shoppingCartItem = context.ShappingCarts
                .FirstOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartIds);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShappingCart
                {
                    ShoppingCartId = ShoppingCartIds,
                    Product = product,
                    Qty = 1
                };
                context.ShappingCarts.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Qty++;
            }

            context.SaveChanges();
        }

        #endregion

        public void ClearCart()
        {
            var cartItems = context.ShappingCarts.Where(s => s.ShoppingCartId == ShoppingCartIds);
            context.ShappingCarts.RemoveRange(cartItems);
            context.SaveChanges();
        }

        public List<ShappingCart> GetCartItems()
        {
            return ShappingCarts ??= context.ShappingCarts
                .Where(s => s.ShoppingCartId == ShoppingCartIds)
                .Include(s => s.Product)
                .ToList();
        }

        public decimal GetCartTotal()
        {
            var totalCost = context.ShappingCarts
                .Where(s => s.ShoppingCartId == ShoppingCartIds)
                .Select(s => s.Product.Price * s.Qty)
                .Sum();
            return totalCost;
        }

        #region removefromcart

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = context.ShappingCarts
                .FirstOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartIds);

            var quantity = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Qty > 1)
                {
                    shoppingCartItem.Qty--;
                    quantity = shoppingCartItem.Qty;
                }
                else
                {
                    context.ShappingCarts.Remove(shoppingCartItem);
                }
            }

            context.SaveChanges();
            return quantity;
        }

        #endregion





        public void UpdateCart(int id, int qty)
        {
            var cartItem = context.ShappingCarts.Find(id); // البحث عن العنصر في العربة باستخدام المعرف
            if (cartItem != null)
            {
                cartItem.Qty = qty; // تحديث الكمية
                context.SaveChanges(); // حفظ التغييرات
            }
        }






    }
}




//public void AddToCart(Product product, int qty, string shoppingCartId)
//{
//    var shoppingCartItem = _context.ShappingCarts
//        .FirstOrDefault(c => c.Product.Id == product.Id && c.ShoppingCartId == shoppingCartId);

//    if (shoppingCartItem == null)
//    {
//        shoppingCartItem = new shappingCartItems
//        {
//            Product = product,
//            Qty = qty,
//            ShoppingCartId = shoppingCartId
//        };
//        _context.ShappingCarts.Add(shoppingCartItem);
//    }
//    else
//    {
//        shoppingCartItem.Qty += qty; // تحديث الكمية إذا كان المنتج موجودًا بالفعل
//    }

//    _context.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
//}


//public void UpdateCart(int id, int qty)
//{
//    var cartItem = _context.ShappingCarts.Find(id); // البحث عن العنصر في العربة باستخدام المعرف
//    if (cartItem != null)
//    {
//        cartItem.Qty = qty; // تحديث الكمية
//        _context.SaveChanges(); // حفظ التغييرات
//    }
//}


//public void RemoveFromCart(int id)
//{
//    var cartItem = _context.ShappingCarts.Find(id); // البحث عن العنصر
//    if (cartItem != null)
//    {
//        _context.ShappingCarts.Remove(cartItem); // إزالة العنصر من العربة
//        _context.SaveChanges(); // حفظ التغييرات
//    }
//}


//public List<shappingCartItems> GetCartItems(string shoppingCartId)
//{
//    return _context.ShappingCarts
//        .Include(c => c.Product) // تضمين معلومات المنتج
//        .Where(c => c.ShoppingCartId == shoppingCartId) // البحث عن العناصر في العربة
//        .ToList(); // تحويل النتائج إلى قائمة
//}


//public decimal GetCartTotal(string shoppingCartId)
//{
//    return _context.ShappingCarts
//        .Where(c => c.ShoppingCartId == shoppingCartId)
//        .Sum(c => c.Product.Price * c.Qty); // حساب المجموع الكلي
//}


//public void ClearCart(string shoppingCartId)
//{
//    var cartItems = _context.ShappingCarts
//        .Where(c => c.ShoppingCartId == shoppingCartId)
//        .ToList(); // جلب جميع العناصر

//    _context.ShappingCarts.RemoveRange(cartItems); // إزالة جميع العناصر
//    _context.SaveChanges(); // حفظ التغييرات
//}
