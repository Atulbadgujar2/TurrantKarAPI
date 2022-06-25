using System;
using System.ComponentModel.DataAnnotations.Schema;
using TK.Entity;

namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all Picture properties.
    /// </summary>
    [Table("Picture")]
    public class Picture : BaseEntity
    {
        public string MimeType { get; set; }

        public string SeoFilename { get; set; }

        public string AltAttribute { get; set; }

        public string TitleAttribute { get; set; }

        public bool IsNew { get; set; }

        public string VirtualPath { get; set; }

        public Guid PictureGuidId { get; set; }

    }
}

