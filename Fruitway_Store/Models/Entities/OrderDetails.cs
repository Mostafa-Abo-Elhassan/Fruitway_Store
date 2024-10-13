namespace Fruitway_Store.Models.Entities
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }

        public Order? Order { get; set; }
        public int ProductId { get; set; }
        public Product? product { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
