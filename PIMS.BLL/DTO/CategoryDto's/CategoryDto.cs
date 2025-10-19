using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMS.BLL.DTO.CategoryDto_s
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        public string Name { get; set; }

    }
}
