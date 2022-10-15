using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Ui.Models
{
	public class RegisterModel 
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; } = default!;

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; } = default!;

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; } = default!;

	}
}
