namespace Fruitway_Store.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string?  Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public decimal OrderTatol { get; set; }

        public DateTime OrderPlaced { get; set; }
        // Navigation property
        public List<OrderDetails> OrderDetails { get; set; } // One-to-many relationship

    }
}
