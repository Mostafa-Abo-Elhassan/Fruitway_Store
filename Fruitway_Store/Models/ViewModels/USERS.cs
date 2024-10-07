﻿using System.ComponentModel.DataAnnotations;

namespace Fruitway_Store.Models.ViewModels
{
    public class USERS
    {
        public List<UserVM> Users { get; set; } = new List<UserVM>(); // تهيئة القائمة



        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = "Username cannot exceed 100 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        //[StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long and cannot exceed 100 characters")]
        public string Password { get; set; }
        public bool checkAdmin { get; set; }
    }
}
