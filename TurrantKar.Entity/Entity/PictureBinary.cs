using System.ComponentModel.DataAnnotations.Schema;
using TK.Entity;

namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all PictureBinary properties.
    /// </summary>
    [Table("PictureBinary")]
    public class PictureBinary : BaseEntity
    {
        public int PictureId { get; set; }

        public int BinaryData { get; set; }
    }
}
