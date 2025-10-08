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
        [Required]
        public int? OrderId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string? PaymentMethod { get; set; }
    }
}
