using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all ShoppingCartItem properties.
    /// </summary>
    [Table("ShoppingCart")]
    public class ShoppingCart : BaseEntity
    {
        public int CustomerId { get; set; }
        public int CoupanId { get; set; }       
        public int ShoppingCartTypeId { get; set; }
       
        public decimal CustomerEnteredPrice { get; set; }
        public decimal DeliveryCharge { get; set; }

        public string DeliveryChargeUrl { get; set; }

        public int CartItemCount { get; set; }

        public decimal DeliveryLimit { get; set; }

        public decimal BagTotal { get; set; }

        public decimal CartTotal { get; set; }

        public decimal CartSaving { get; set; }

        public decimal OrderTotal { get; set; }
        public bool IsCoupanApplied { get; set; }
        public DateTime? RentalStartDateUtc { get; set; }
        public DateTime? RentalEndDateUtc { get; set; }

    }
}

