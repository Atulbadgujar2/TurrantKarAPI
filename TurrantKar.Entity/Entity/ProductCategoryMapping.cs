using System.ComponentModel.DataAnnotations.Schema;
using TK.Entity;

namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all ProductCategoryMapping properties.
    /// </summary>
    [Table("ProductCategoryMapping")]
    public class ProductCategoryMapping : BaseEntity
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }

        public bool IsFeaturedProduct { get; set; }

        public int DisplayOrder { get; set; }

      
    }
}

