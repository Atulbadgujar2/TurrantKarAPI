using System.ComponentModel.DataAnnotations.Schema;


namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all ProductTemplate properties.
    /// </summary>
    [Table("ProductTemplate")]
    public class ProductTemplate : BaseEntity
    {
        public string Name { get; set; }

        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }

        public string IgnoredProductTypes { get; set; }

        
    }
}
