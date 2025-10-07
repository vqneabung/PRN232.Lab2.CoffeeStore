using System.ComponentModel.DataAnnotations;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request
{
	public class Login
	{
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
	}
}
