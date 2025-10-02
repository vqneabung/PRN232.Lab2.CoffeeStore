namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request
{
	public class RefreshTokenRequest
	{
		public required Guid UserId { get; set; }
		public required string RefreshToken { get; set; }
	}
}
