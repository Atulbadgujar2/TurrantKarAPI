using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurrantKar.DTO
{
    public class ProductTemplateDTO : BaseDTO
    {
        public string Name { get; set; }

        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }

        public string IgnoredProductTypes { get; set; }
    }
}
