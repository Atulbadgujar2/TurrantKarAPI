using System.ComponentModel.DataAnnotations.Schema;
using TK.Entity;

namespace TurrantKar.Entity
{
    /// <summary>
    /// this entity represting all Address properties.
    /// </summary>
    [Table("Address")]
    public class Address : BaseEntity
    {
        public string County { get; set; }


        public string City { get; set; }


        public string Address1 { get; set; }


        public string ZipPostalCode { get; set; }
    }
}
   
