using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage ="Email is requered")]
		[EmailAddress(ErrorMessage ="Invalid Email")]
		public string Email {  get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage ="Password is required")]
		[MinLength(5, ErrorMessage ="Minimum Password lenght is 5")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage ="Confirm password is required")]
		[Compare("Password", ErrorMessage ="Confirm password does not match password")]
		public string ConfirmPAssword { get; set; }
		
		public bool IsAgree { get; set; }
	}
}
