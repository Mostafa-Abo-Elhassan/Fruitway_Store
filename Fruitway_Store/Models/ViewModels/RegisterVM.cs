using System.ComponentModel.DataAnnotations;

namespace Fruitway_Store.Models.ViewModels
{
	public class RegisterVM
	{
		[Required]
		[Display(Name = "User Name")]
		public string UserName { get; set; }
		//[unique]
		[Required]
		[EmailAddress]
		[Display(Name = "Email Address")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

	}
}
