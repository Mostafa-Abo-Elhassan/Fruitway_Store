﻿using System.ComponentModel.DataAnnotations;

namespace Fruitway_Store.Models.ViewModels
{
    public class AddProductVM
    {
        [MaxLength(100)]
        public string? Name { get; set; }


        public string? Detail { get; set; }

        public string? ImageUrl { get; set; }


        public decimal Price { get; set; }


        public bool IsTrandingProduct { get; set; }

    }
}
