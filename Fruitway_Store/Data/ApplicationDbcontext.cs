using Fruitway_Store.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Emit;
using Fruitway_Store.Repository.IRepo;

namespace Fruitway_Store.Data
{
    public class ApplicationDbcontext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options) { }




        public DbSet<Product> Products { get; set; }


        public DbSet<ShappingCart> ShappingCarts { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Product>().HasData(

        //      new Product { Id = 1, Name = "Lemon", Detail = "Lorem ipsum dolor sit amet, consectetur adipisicing elit.", Price = 85, IsTrandingProduct = true, ImageUrl = "" },
        //      new Product { Id = 2, Name = "Berry", Detail = "Lorem ipsum dolor sit amet, consectetur adipisicing elit.", Price = 70, IsTrandingProduct = true, ImageUrl = "" },
        //      new Product { Id = 3, Name = "Strawberry", Detail = "Lorem ipsum dolor sit amet, consectetur adipisicing elit.", Price = 45, IsTrandingProduct = true, ImageUrl = "" },
        //      new Product { Id = 4, Name = "Strawberry", Detail = "Lorem ipsum dolor sit amet, consectetur adipisicing elit.", Price = 50, IsTrandingProduct = true, ImageUrl = "" },
        //      new Product { Id = 5, Name = "Green Apple", Detail = "Lorem ipsum dolor sit amet, consectetur adipisicing elit.", Price = 60, IsTrandingProduct = true, ImageUrl = "" },
        //      new Product { Id = 6, Name = "Avocado", Detail = "Lorem ipsum dolor sit amet, consectetur adipisicing elit.", Price = 100, IsTrandingProduct = true, ImageUrl = "" }




        //        );



        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                 .Property(p => p.Price)
                 .HasColumnType("decimal(18,2)");

            builder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(200);

            builder.Entity<Product>()
                .Property(p => p.Detail)
                .HasMaxLength(1000);

            builder.Entity<Product>()
                .Property(p => p.ImageUrl)
                .HasMaxLength(500);
            //builder.Entity<OrderDetails>()
            //    .HasNoKey(); 
                    // Seed Roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "2a768bee-f40e-4183-9736-2c0cae0ba9f3", // Admin
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole()
                {
                    Id = "9b5649ea-6db6-482a-a83e-73633a72c2ce", // User
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole()
                {
                    Id = "1b892d2e-2158-4170-91ec-08839cd0f4d4", // Super_Admin
                    Name = "Super_Admin",
                    NormalizedName = "SUPER_ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                }
            );

            // Seed SuperAdmin User
            var superAdmin = new IdentityUser
            {
                Id = "20F5B72B-5F5E-4D40-A45B-509A01FF187F", // SuperAdmin user ID
                UserName = "superadmin@gmail.com",
                NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                EmailConfirmed = true
            };

            // Hash and assign password
            var passwordHasher = new PasswordHasher<IdentityUser>();
            superAdmin.PasswordHash = passwordHasher.HashPassword(superAdmin, "superadmin@gmail.com");

            // Add SuperAdmin user to IdentityUser entity
            builder.Entity<IdentityUser>().HasData(superAdmin);

            // Seed Roles for SuperAdmin User
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "20F5B72B-5F5E-4D40-A45B-509A01FF187F", // SuperAdmin user ID
                    RoleId = "1b892d2e-2158-4170-91ec-08839cd0f4d4"  // Super_Admin role ID
                },
                new IdentityUserRole<string>
                {
                    UserId = "20F5B72B-5F5E-4D40-A45B-509A01FF187F", // SuperAdmin user ID
                    RoleId = "2a768bee-f40e-4183-9736-2c0cae0ba9f3"  // Admin role ID
                },
                new IdentityUserRole<string>
                {
                    UserId = "20F5B72B-5F5E-4D40-A45B-509A01FF187F", // SuperAdmin user ID
                    RoleId = "9b5649ea-6db6-482a-a83e-73633a72c2ce"  // User role ID
                }
            );

            base.OnModelCreating(builder);
        }


    }
}



























