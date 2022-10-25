using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurrantKar.Entity;

namespace TurrantKar.DTO
{
    public class  OrderItemDTO : BaseDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Guid OrderItemGuid { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPriceInclTax { get; set; }
        public decimal UnitPriceExclTax { get; set; }
        public decimal PriceInclTax { get; set; }
        public decimal PriceExclTax { get; set; }
        public decimal DiscountAmountInclTax { get; set; }
        public decimal DiscountAmountExclTax { get; set; }
        public decimal OriginalProductCost { get; set; }
        public string AttributeDescription { get; set; }
        public string AttributesXml { get; set; }
        public int DownloadCount { get; set; }
        public bool IsDownloadActivated { get; set; }
        public int? LicenseDownloadId { get; set; }
        public decimal ItemWeight { get; set; }
        public DateTime? RentalStartDateUtc { get; set; }
        public DateTime? RentalEndDateUtc { get; set; }
        public bool IsRecurringProduct { get; set; }
        public int SubscriptionPriceId { get; set; }

        public static OrderItem MapToEntity(OrderItemDTO model)
        {
            OrderItem entity = new OrderItem();
            entity.OrderId = model.OrderId;
            entity.ProductId = model.ProductId;
            entity.OrderItemGuid = model.OrderItemGuid;
            entity.Quantity = model.Quantity;
            entity.UnitPriceInclTax = model.UnitPriceInclTax;
            entity.UnitPriceExclTax = model.UnitPriceExclTax;
            entity.PriceInclTax = model.PriceInclTax;
            entity.PriceExclTax = model.PriceExclTax;
            entity.DiscountAmountExclTax = model.DiscountAmountExclTax;
            entity.DiscountAmountInclTax = model.DiscountAmountInclTax;
            entity.AttributesXml = model.AttributesXml;
            entity.OriginalProductCost = model.OriginalProductCost;
            entity.AttributeDescription = model.AttributeDescription;
            entity.DownloadCount = model.DownloadCount;
            entity.IsDownloadActivated = model.IsDownloadActivated;
            entity.LicenseDownloadId = model.LicenseDownloadId;
            entity.ItemWeight = model.ItemWeight;
            entity.RentalEndDateUtc = model.RentalEndDateUtc;
            entity.RentalStartDateUtc = model.RentalStartDateUtc;
            entity.IsRecurringProduct = model.IsRecurringProduct;
            entity.SubscriptionPriceId = model.SubscriptionPriceId;
            return entity;
        }

        public static OrderItem MapToEntityWithEntity(OrderItemDTO model, OrderItem entity)
        {
            entity.OrderId = model.OrderId;
            entity.ProductId = model.ProductId;
            entity.OrderItemGuid = model.OrderItemGuid;
            entity.Quantity = model.Quantity;
            entity.UnitPriceInclTax = model.UnitPriceInclTax;
            entity.UnitPriceExclTax = model.UnitPriceExclTax;
            entity.PriceInclTax = model.PriceInclTax;
            entity.PriceExclTax = model.PriceExclTax;
            entity.DiscountAmountExclTax = model.DiscountAmountExclTax;
            entity.DiscountAmountInclTax = model.DiscountAmountInclTax;
            entity.AttributesXml = model.AttributesXml;
            entity.OriginalProductCost = model.OriginalProductCost;
            entity.AttributeDescription = model.AttributeDescription;
            entity.DownloadCount = model.DownloadCount;
            entity.IsDownloadActivated = model.IsDownloadActivated;
            entity.LicenseDownloadId = model.LicenseDownloadId;
            entity.ItemWeight = model.ItemWeight;
            entity.RentalEndDateUtc = model.RentalEndDateUtc;
            entity.RentalStartDateUtc = model.RentalStartDateUtc;
            entity.IsRecurringProduct = model.IsRecurringProduct;
            entity.SubscriptionPriceId = model.SubscriptionPriceId;
            return entity;
        }
    }
}
