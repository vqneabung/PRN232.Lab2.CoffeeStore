using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request
{
    public class UpdateCategoryRequest : CommonCategoryRequest
    {
        [Required]
        public Guid? CategoryId { get; set; }
    }
}
