using System.ComponentModel.DataAnnotations.Schema;
using TK.Entity;

namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all CustomerAddresses properties.
    /// </summary>
    [Table("CustomerAddresses")]
    public class CustomerAddresses : BaseEntity
    {
        public int Address_Id { get; set; }

        public int Customer_Id { get; set; }
        
    }
}
