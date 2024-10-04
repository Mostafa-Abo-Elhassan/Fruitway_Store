using System.ComponentModel.DataAnnotations;

namespace Fruitway_Store.Models.ViewModels
{
	public class LoginVM
	{
		[Required]
		[Display(Name = "User Name")]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }

		//public string? ReturnUrl { get; set; }
	}
}
