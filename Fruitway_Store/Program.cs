using Fruitway_Store.Data;
using Fruitway_Store.Repository.IRepo;
using Fruitway_Store.Repository.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fruitway_Store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSession();
            builder.Services.AddControllersWithViews();

            //builder.Services.AddScoped<IshappingCart, ShoppingCartRepo>(s => ShoppingCartRepo.GetCart(s));
            builder.Services.AddScoped<IshappingCart, ShoppingCartRepo>(ShoppingCartRepo.GetCart);
            builder.Services.AddDbContext<ApplicationDbcontext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("Fruitway")));
            builder.Services.AddScoped<IProductRepo,ProductRepo>();
			builder.Services.AddScoped<IAdminProduct, AdminProductRepo>();
            builder.Services.AddScoped<Iuser, UserRepo>();
            //builder.Services.AddScoped<IshappingCart>(ShoppingCartRepo.GetCart());
            

            //builder.Services.AddScoped<IshappingCart,ShoppingCartRepo>(ShoppingCartRepo.GetCart());
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
	 options.SignIn.RequireConfirmedAccount = true)
		 .AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbcontext>();


			builder.Services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = true;


			});

			var app = builder.Build();
            app.UseSession();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthorization();
            app.UseSession(); // ????? ??? Session
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
