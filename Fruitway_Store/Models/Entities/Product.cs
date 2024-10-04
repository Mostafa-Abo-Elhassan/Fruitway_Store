using System.ComponentModel.DataAnnotations;

namespace Fruitway_Store.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        
        public string? Name { get; set; }

        
        public string? Detail { get; set; }

        public string? ImageUrl { get; set; }


        public decimal Price { get; set; }


        public bool IsTrandingProduct { get; set; }




    }
}
