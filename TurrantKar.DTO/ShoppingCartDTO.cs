using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurrantKar.DTO
{
    public class ShoppingCartDTO : BaseDTO
    {
        public int CustomerId { get; set; }

        public int StoreId { get; set; }
        public int ShoppingCartTypeId { get; set; }

        public decimal CustomerEnteredPrice { get; set; }

        public string DeliveryChargeUrl { get; set; }

        public string DeliveryCharge { get; set; }

        public string CartItemCount { get; set; }

        public string DeliveryLimit { get; set; }

        public string BagTotal { get; set; }

        public string CartTotal { get; set; }

        public string CartSaving { get; set; }

        public string OrderTotal { get; set; }

        public DateTime? RentalStartDateUtc { get; set; }
        public DateTime? RentalEndDateUtc { get; set; }

        public bool Active { get; set; }

        public ShoppingCartItemDTO shopCartItem { get; set; }


    }
}
