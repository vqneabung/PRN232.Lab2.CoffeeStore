using System.ComponentModel.DataAnnotations;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request
{
	public class RegisterRequest
	{
		public string? Username { get; set; }

		public string? FullName { get; set; }

		public string Email { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;

	}
}
