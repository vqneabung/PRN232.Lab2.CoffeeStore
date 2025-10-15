using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response
{
    public class OrderDetailResponse
    {
        public Guid OrderDetailId { get; set; }

        public Guid? OrderId { get; set; }

        public Guid? ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public bool? IsActive { get; set; }

    }
}
