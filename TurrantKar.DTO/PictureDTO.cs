using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurrantKar.DTO
{
    public class PictureDTO : BaseDTO
    {
        public string MimeType { get; set; }

        public string SeoFilename { get; set; }

        public string AltAttribute { get; set; }

        public string TitleAttribute { get; set; }

        public bool IsNew { get; set; }

        public string VirtualPath { get; set; }
    }
}
