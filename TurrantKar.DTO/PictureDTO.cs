using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurrantKar.Entity;

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

        public Guid PictureGuidId { get; set; }

        public static Picture MapToEntity(FileUploadDTO model)
        {
            Picture entity = new Picture();
            //entity.MimeType = Path.GetExtension(model.FileName);
            entity.MimeType = model.FileType;          
            entity.IsNew = true;
            entity.SeoFilename = model.FileName;
            entity.VirtualPath = model.VirtualPath;
            return entity;
        }
    }

  
}
