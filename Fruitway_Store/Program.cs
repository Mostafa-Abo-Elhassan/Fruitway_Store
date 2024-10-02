using Fruitway_Store.Data;
using Fruitway_Store.Repository.IRepo;
using Fruitway_Store.Repository.Repo;
using Microsoft.EntityFrameworkCore;

namespace Fruitway_Store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Fruitway")));
            builder.Services.AddScoped<IProductRepo,ProductRepo>();
			builder.Services.AddScoped<IAdminProduct, AdminProductRepo>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
