using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace TurrantKar.Entity
{
    /// <summary>
    /// this entity represting all CategoryPictureMapping properties.
    /// </summary>
    [Table("CategoryPictureMapping")]
    public class CategoryPictureMapping : BaseEntity
    {
        public Guid PictureId { get; set; }
        public int CategoryId { get; set; }

        public int DisplayOrder { get; set; }


    }
}
