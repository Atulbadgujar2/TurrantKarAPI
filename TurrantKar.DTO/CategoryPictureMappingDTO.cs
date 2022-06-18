using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurrantKar.DTO
{
    public class CategoryPictureMappingDTO : BaseDTO
    {
        public int PictureId { get; set; }
        public int CategoryId { get; set; }

        public int DisplayOrder { get; set; }
    }
}
