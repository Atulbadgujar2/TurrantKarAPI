using System.ComponentModel.DataAnnotations.Schema;
using TK.Entity;

namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all OrderNote properties.
    /// </summary>
    [Table("OrderNote")]
    public class OrderNote : BaseEntity
    {

        public string Note { get; set; }

        public int OrderId { get; set; }

        public int DownloadId { get; set; }

        public bool DisplayToCustomer { get; set; }
    }
}

