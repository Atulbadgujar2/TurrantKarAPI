using System;

namespace TurrantKar.DTO
{
    public class ShoppingCartItemDTO : BaseDTO
    {

        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public int ShoppingCartId { get; set; }
        public int StoreId { get; set; }
        public int ShoppingCartTypeId { get; set; }
        public string AttributesXml { get; set; }
        public decimal CustomerEnteredPrice { get; set; }
        public int Quantity { get; set; }
        public string QuantityMRP { get; set; }
        public DateTime? RentalStartDateUtc { get; set; }
        public DateTime? RentalEndDateUtc { get; set; }

        public bool Active { get; set; }
    }
}
