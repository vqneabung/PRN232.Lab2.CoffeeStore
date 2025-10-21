using System.ComponentModel.DataAnnotations;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request
{
	public class RegisterRequest
	{
		[Required]
		public string? Username { get; set; }

		public string? FullName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		public string Password { get; set; } = string.Empty;

	}
}
