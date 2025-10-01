using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request
{
    public class CommonPaymentRequest
    {
        public int? OrderId { get; set; }

        public decimal Amount { get; set; }

        public string? PaymentMethod { get; set; }
    }
}
