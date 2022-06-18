using System.ComponentModel.DataAnnotations.Schema;
using TK.Entity;

namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all ProductPictureMapping properties.
    /// </summary>
    [Table("ProductPictureMapping")]
    public class ProductPictureMapping : BaseEntity
    {
        public int PictureId { get; set; }

        public int ProductId { get; set; }

        public int DisplayOrder { get; set; }
    }
}
