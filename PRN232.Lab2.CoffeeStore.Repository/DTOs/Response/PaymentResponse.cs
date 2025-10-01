﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response
{
    public class PaymentResponse
    {
        public int PaymentId { get; set; }

        public int? OrderId { get; set; }

        public decimal Amount { get; set; }

        public DateTime? PaymentDate { get; set; }

        public string? PaymentMethod { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}
