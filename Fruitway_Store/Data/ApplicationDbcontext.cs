using Fruitway_Store.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fruitway_Store.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options) { }




        public DbSet<Product> Products { get; set; }


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

    }
}
