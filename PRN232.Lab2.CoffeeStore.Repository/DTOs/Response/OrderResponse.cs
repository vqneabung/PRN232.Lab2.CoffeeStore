using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response
{
    public class OrderResponse
    {
        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }

        public DateTime? OrderDate { get; set; } = DateTime.Now;

        public string? Status { get; set; }

        public Guid? PaymentId { get; set; }

        public bool? IsActive { get; set; } = true;

    }
}
