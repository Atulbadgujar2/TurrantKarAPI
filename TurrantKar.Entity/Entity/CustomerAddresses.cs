using System.ComponentModel.DataAnnotations.Schema;


namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all CustomerAddresses properties.
    /// </summary>
    [Table("CustomerAddresses")]
    public class CustomerAddresses : BaseEntity
    {
        public int AddressId { get; set; }

        public int CustomerId { get; set; }
        
    }
}
