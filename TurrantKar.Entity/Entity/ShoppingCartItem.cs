using System;
using System.ComponentModel.DataAnnotations.Schema;
using TK.Entity;

namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all ShoppingCartItem properties.
    /// </summary>
    [Table("ShoppingCartItem")]
    public class ShoppingCartItem : BaseEntity
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int ShoppingCartTypeId { get; set; }
        public string AttributesXml { get; set; }
        public decimal CustomerEnteredPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime? RentalStartDateUtc { get; set; }
        public DateTime? RentalEndDateUtc { get; set; }
    }
}
