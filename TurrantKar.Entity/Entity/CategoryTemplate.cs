using System;
using System.ComponentModel.DataAnnotations.Schema;
using TK.Entity;

namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all CategoryTemplate properties.
    /// </summary>
    [Table("CategoryTemplate")]
    public class CategoryTemplate : BaseEntity
    {
        public string Name { get; set; }

        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }

        public Guid ImageGuid { get; set; }
    }
}
