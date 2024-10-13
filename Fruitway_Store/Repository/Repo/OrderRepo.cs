using Fruitway_Store.Data;
using Fruitway_Store.Models.Entities;
using Fruitway_Store.Repository.IRepo;

namespace Fruitway_Store.Repository.Repo
{
    public class OrderRepo : IOrderRepo
    {
     
        private readonly ApplicationDbcontext dbcontext;
        private readonly IshappingCart ishapping;
       
        public OrderRepo(ApplicationDbcontext dbcontext, IshappingCart ishapping)
        {
            this.dbcontext = dbcontext;
            this.ishapping = ishapping;
          
        }
        public void PlaceOrder(Order order)
        {
            var shoppingcart = ishapping.GetCartItems();
            order.OrderDetails = new List<OrderDetails>();
            foreach (var item in shoppingcart)
            {
                var Orderdetail = new OrderDetails
                {
                    ProductId= item.Product.Id,
                    Quantity =item.Qty,
                    Price = item.Product.Price
                };
                order.OrderDetails.Add(Orderdetail);
            }
            order.OrderPlaced = DateTime.Now;
            order.OrderTatol = ishapping.GetCartTotal();
            dbcontext.Orders.Add(order);
            dbcontext.SaveChanges();



        }
    }
}
