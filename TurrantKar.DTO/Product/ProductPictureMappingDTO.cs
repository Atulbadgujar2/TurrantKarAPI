using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurrantKar.DTO
{
    public class  ProductPictureMappingDTO : BaseDTO
    {
        public int PictureId { get; set; }

        public int ProductId { get; set; }

        public int DisplayOrder { get; set; }
    }
}
