using Fruitway_Store.Models;
using Fruitway_Store.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fruitway_Store.Controllers
{
    public class HomeController : Controller
    {
		private readonly IProductRepo repo;

		public HomeController(IProductRepo repo)
        {
			this.repo = repo;
		}
        public IActionResult Index()
        {

			var allProducts = repo.GetTrandingProducts();
			if (allProducts == null)
			{
				return NotFound();

			}
			return View(allProducts);

			
        }

		public IActionResult NOTFOUND()
		{
			return View();
		}
		public IActionResult About()
		{
			return View();
		}
		public IActionResult Contact()
		{
			return View();
		}


	}
}
