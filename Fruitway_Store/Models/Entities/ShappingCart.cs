namespace Fruitway_Store.Models.Entities
{
    public class ShappingCart
	{
        public int Id { get; set; } // معرف فريد لعنصر العربة

        public Product? Product { get; set; } // المنتج الموجود في العربة
        public int Qty { get; set; } // الكمية من المنتج

        public string? ShoppingCartId { get; set; } // معرف عربة التسوق

    }
}
