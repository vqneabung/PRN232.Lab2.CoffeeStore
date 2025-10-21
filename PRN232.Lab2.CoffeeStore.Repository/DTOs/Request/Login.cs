using System.ComponentModel.DataAnnotations;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request
{
	public class Login
	{
		[Required]
		[EmailAddress]
		public string? Email { get; set; } = null!;
		[Required]
		public string? Password { get; set; } = null!;
	}
}
