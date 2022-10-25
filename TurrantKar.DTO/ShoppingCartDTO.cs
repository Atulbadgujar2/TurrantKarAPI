using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurrantKar.Entity;

namespace TurrantKar.DTO
{
    public class ShoppingCartDTO : BaseDTO
    {
        public int CustomerId { get; set; }

        public int StoreId { get; set; }
        public int ShoppingCartTypeId { get; set; }

        public decimal CustomerEnteredPrice { get; set; }

        public string DeliveryChargeUrl { get; set; }

        public decimal DeliveryCharge { get; set; }

        public int CartItemCount { get; set; }

        public decimal DeliveryLimit { get; set; }

        public int BagTotal { get; set; }

        public int CartTotal { get; set; }

        public decimal CartSaving { get; set; }

        public decimal OrderTotal { get; set; }

        public DateTime? RentalStartDateUtc { get; set; }
        public DateTime? RentalEndDateUtc { get; set; }

        public bool Active { get; set; }

        public List<ShoppingCartItemDTO> shopCartItemList { get; set; }


        public static ShoppingCart MapToEntity(ShoppingCartDTO model)
        {
            ShoppingCart entity = new ShoppingCart();
            entity.CustomerId = model.CustomerId;
            entity.ShoppingCartTypeId = model.ShoppingCartTypeId;
            entity.CustomerEnteredPrice = model.CustomerEnteredPrice;
            entity.DeliveryChargeUrl = model.DeliveryChargeUrl;
            entity.DeliveryCharge = model.DeliveryCharge;
            entity.CartItemCount = model.CartItemCount;
            entity.DeliveryLimit = model.DeliveryLimit;
            entity.BagTotal = model.BagTotal;
            entity.CartTotal = model.CartTotal;
            entity.CartSaving = model.CartSaving;
            entity.OrderTotal = model.OrderTotal;
            entity.RentalStartDateUtc = model.RentalStartDateUtc;
            entity.RentalEndDateUtc = model.RentalEndDateUtc;
            entity.Active = model.Active;
         
            return entity;
        }

        public static ShoppingCart MapToEntityWithEntity(ShoppingCartDTO model, ShoppingCart entity)
        {
            entity.CustomerId = model.CustomerId;
            entity.ShoppingCartTypeId = model.ShoppingCartTypeId;
            entity.CustomerEnteredPrice = model.CustomerEnteredPrice;
            entity.DeliveryChargeUrl = model.DeliveryChargeUrl;
            entity.DeliveryCharge = model.DeliveryCharge;
            entity.CartItemCount = model.CartItemCount;
            entity.DeliveryLimit = model.DeliveryLimit;
            entity.BagTotal = model.BagTotal;
            entity.CartTotal = model.CartTotal;
            entity.CartSaving = model.CartSaving;
            entity.OrderTotal = model.OrderTotal;
            entity.RentalStartDateUtc = model.RentalStartDateUtc;
            entity.RentalEndDateUtc = model.RentalEndDateUtc;
            entity.Active = model.Active;
            return entity;
        }


    }
}
