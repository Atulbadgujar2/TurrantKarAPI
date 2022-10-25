using System;
using TurrantKar.Entity;

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

        public static ShoppingCartItem MapToEntity(ShoppingCartItemDTO model)
        {
            ShoppingCartItem entity = new ShoppingCartItem();    
            entity.CustomerId = model.CustomerId;
            entity.ProductId = model.ProductId;
            entity.ShoppingCartId = model.ShoppingCartId;
            entity.StoreId = model.StoreId;
            entity.ShoppingCartTypeId = model.ShoppingCartTypeId;
            entity.AttributesXml = model.AttributesXml;
            entity.CustomerEnteredPrice = model.CustomerEnteredPrice;
            entity.Quantity = model.Quantity;
            entity.QuantityMRP = model.QuantityMRP;
            entity.RentalStartDateUtc = model.RentalStartDateUtc;
            entity.RentalEndDateUtc = model.RentalEndDateUtc;
            entity.Active = model.Active;

            return entity;
        }


        public static ShoppingCartItem MapToEntityWithEntity(ShoppingCartItemDTO model, ShoppingCartItem entity)
        {
            entity.CustomerId = model.CustomerId;
            entity.ProductId = model.ProductId;
            entity.ShoppingCartId = model.ShoppingCartId;
            entity.StoreId = model.StoreId;
            entity.ShoppingCartTypeId = model.ShoppingCartTypeId;
            entity.AttributesXml = model.AttributesXml;
            entity.CustomerEnteredPrice = model.CustomerEnteredPrice;
            entity.Quantity = model.Quantity;
            entity.QuantityMRP = model.QuantityMRP;
            entity.RentalStartDateUtc = model.RentalStartDateUtc;
            entity.RentalEndDateUtc = model.RentalEndDateUtc;
            entity.Active = model.Active;
            return entity;
        }

    }
}
