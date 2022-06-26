﻿using System.ComponentModel.DataAnnotations.Schema;


namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all PictureBinary properties.
    /// </summary>
    [Table("PictureBinary")]
    public class PictureBinary : BaseEntity
    {
        public int PictureId { get; set; }

        public byte[] BinaryData { get; set; }
    }
}
