using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response
{
    public class OrderResponse
    {
        public int OrderId { get; set; }

        public string? UserId { get; set; }

        public DateTime? OrderDate { get; set; }

        public string? Status { get; set; }

        public int? PaymentId { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}
