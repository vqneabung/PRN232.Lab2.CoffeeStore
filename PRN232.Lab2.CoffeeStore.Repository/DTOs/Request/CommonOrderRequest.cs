using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request
{
    public class CommonOrderRequest
    {
        public string? UserId { get; set; }

        public string? Status { get; set; }

        public int? PaymentId { get; set; }

    }
}
