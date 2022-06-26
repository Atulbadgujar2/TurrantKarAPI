using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurrantKar.DTO
{
    public class  ProductCategoryMappingDTO : BaseDTO
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }

        public bool IsFeaturedProduct { get; set; }

        public int DisplayOrder { get; set; }
    }
}
