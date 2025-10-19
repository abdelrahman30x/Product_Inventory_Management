using PIMS.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMS.DAL.Models.Category
{
    public class Category : ModelBase
    {
        public virtual ICollection<Product.Product>? Products { get; set; } = new HashSet<Product.Product>();

    }
}
