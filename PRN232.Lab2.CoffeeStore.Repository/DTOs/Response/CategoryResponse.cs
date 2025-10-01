﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response
{
    public class CategoryResponse
    {

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? IsActive { get; set; } = true;

    }
}
