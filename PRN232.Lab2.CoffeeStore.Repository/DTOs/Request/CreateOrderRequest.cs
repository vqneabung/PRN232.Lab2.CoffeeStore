using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request
{
    public class CreateOrderRequest : CommonOrderRequest
    {
        public List<CommonOrderDetailRequest>? OrderDetails { get; set; }

        public CommonPaymentRequest? Payment { get; set; }
    }
}
