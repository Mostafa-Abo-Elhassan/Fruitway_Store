using Fruitway_Store.Models.Entities;

namespace Fruitway_Store.Repository.IRepo
{
    public interface IOrderRepo
    {
        void PlaceOrder(Order order);
    }
}
