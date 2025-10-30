using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request
{
    public class CommonPaymentRequest
    {
        public Guid? OrderId { get; set; }

        // Amout should be optional, default to 0
        // Must be greater than or equal to 0
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be greater than or equal to 0")]
        public decimal? Amount { get; set; } = 0;

        [Required]
        public string? PaymentMethod { get; set; }
    }
}
