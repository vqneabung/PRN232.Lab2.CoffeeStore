using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response
{
	public class TokenResponse
	{
		public required string AccessToken { get; set; }
		public required string RefreshToken { get; set; }
	}
}
