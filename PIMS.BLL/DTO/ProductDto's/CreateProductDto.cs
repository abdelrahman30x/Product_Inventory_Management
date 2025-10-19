using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMS.BLL.DTO.ProductDto_s
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}

