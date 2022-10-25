using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurrantKar.Entity;

namespace TurrantKar.DTO
{
    public class  OrderDTO : BaseDTO
    {
        public string CustomOrderNumber { get; set; }
        public int BillingAddressId { get; set; }
        public int CustomerId { get; set; }
        public int? PickupAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public Guid OrderGuid { get; set; }
        public int StoreId { get; set; }
        public bool PickupInStore { get; set; }
        public int OrderStatusId { get; set; }
        public int ShippingStatusId { get; set; }
        public int PaymentStatusId { get; set; }
        public string PaymentMethodSystemName { get; set; }
        public string CustomerCurrencyCode { get; set; }
        public decimal CurrencyRate { get; set; }
        public int CustomerTaxDisplayTypeId { get; set; }
        public string VatNumber { get; set; }
        public decimal OrderSubtotalInclTax { get; set; }
        public decimal OrderSubtotalExclTax { get; set; }
        public decimal OrderSubTotalDiscountInclTax { get; set; }
        public decimal OrderSubTotalDiscountExclTax { get; set; }
        public decimal OrderShippingInclTax { get; set; }
        public decimal OrderShippingExclTax { get; set; }
        public decimal PaymentMethodAdditionalFeeInclTax { get; set; }
        public decimal PaymentMethodAdditionalFeeExclTax { get; set; }
        public string TaxRates { get; set; }
        public decimal OrderTax { get; set; }
        public decimal OrderDiscount { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal RefundedAmount { get; set; }
        public int RewardPointsHistoryEntryId { get; set; }
        public string CheckoutAttributeDescription { get; set; }
        public string CheckoutAttributesXml { get; set; }
        public int CustomerLanguageId { get; set; }
        public int AffiliateId { get; set; }
        public string CustomerIp { get; set; }
        public bool AllowStoringCreditCardNumber { get; set; }
        public string CardType { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string MaskedCreditCardNumber { get; set; }
        public string CardCvv2 { get; set; }
        public string CardExpirationMonth { get; set; }
        public string CardExpirationYear { get; set; }
        public string AuthorizationTransactionId { get; set; }
        public string AuthorizationTransactionCode { get; set; }
        public string AuthorizationTransactionResult { get; set; }
        public string CaptureTransactionId { get; set; }
        public string CaptureTransactionResult { get; set; }
        public string SubscriptionTransactionId { get; set; }
        public DateTime? PaidDateUtc { get; set; }
        public string ShippingMethod { get; set; }
        public string ShippingRateComputationMethodSystemName { get; set; }
        public string CustomValuesXml { get; set; }
        public int? RedeemedRewardPointsEntryId { get; set; }

        public List<OrderItemDTO> orderItemDTOList { get; set; }

        public static Order MapToEntity(OrderDTO model)
        {
            Order entity = new Order();
            entity.AffiliateId = model.AffiliateId;
            entity.AllowStoringCreditCardNumber = model.AllowStoringCreditCardNumber;
            entity.AuthorizationTransactionCode = model.AuthorizationTransactionCode;
            entity.AuthorizationTransactionId = model.AuthorizationTransactionId;
            entity.AuthorizationTransactionResult = model.AuthorizationTransactionResult;
            entity.BillingAddressId = model.BillingAddressId;
            entity.CaptureTransactionId = model.CaptureTransactionId;
            entity.CustomerId = model.CustomerId;
            entity.CustomOrderNumber = model.CustomOrderNumber;
            entity.CardCvv2 = model.CardCvv2;
            entity.CaptureTransactionResult = model.CaptureTransactionResult;
            entity.CardExpirationMonth = model.CardExpirationMonth;
            entity.CardExpirationYear = model.CardExpirationYear;
            entity.CardName = model.CardName;
            entity.CardNumber = model.CardNumber;        
            entity.CardType = model.CardType;
            entity.CheckoutAttributeDescription = model.CheckoutAttributeDescription;
            entity.CheckoutAttributesXml = model.CheckoutAttributesXml;
            entity.CurrencyRate = model.CurrencyRate;
            entity.CustomerCurrencyCode = model.CustomerCurrencyCode;
            entity.CustomerIp = model.CustomerIp;
            entity.CustomerLanguageId = model.CustomerLanguageId;
            entity.CustomerTaxDisplayTypeId = model.CustomerTaxDisplayTypeId;
            entity.CustomValuesXml = model.CustomValuesXml;
            entity.MaskedCreditCardNumber = model.MaskedCreditCardNumber;         
            entity.PickupAddressId = model.PickupAddressId;
            entity.PaymentMethodSystemName = model.PaymentMethodSystemName;
            entity.PaymentStatusId = model.PaymentStatusId;
            entity.PickupInStore = model.PickupInStore;
            entity.PaidDateUtc = model.PaidDateUtc;
            entity.PaymentMethodAdditionalFeeExclTax = model.PaymentMethodAdditionalFeeExclTax;
            entity.PaymentMethodAdditionalFeeInclTax = model.PaymentMethodAdditionalFeeInclTax;
            entity.OrderDiscount = model.OrderDiscount;
            entity.OrderGuid = model.OrderGuid;
            entity.OrderShippingExclTax = model.OrderShippingExclTax;
            entity.OrderShippingInclTax = model.OrderShippingInclTax;
            entity.OrderStatusId = model.OrderStatusId;
            entity.OrderSubTotalDiscountExclTax = model.OrderSubTotalDiscountExclTax;
            entity.OrderSubTotalDiscountInclTax = model.OrderSubTotalDiscountInclTax;
            entity.OrderSubtotalExclTax = model.OrderSubtotalExclTax;
            entity.OrderSubtotalInclTax = model.OrderSubtotalInclTax;
            entity.OrderTax = model.OrderTax;
            entity.OrderTotal = model.OrderTotal;
            entity.RedeemedRewardPointsEntryId = model.RedeemedRewardPointsEntryId;
            entity.RefundedAmount = model.RefundedAmount;
            entity.RewardPointsHistoryEntryId = model.RewardPointsHistoryEntryId;
            entity.ShippingAddressId = model.ShippingAddressId;
            entity.StoreId = model.StoreId;
            entity.ShippingMethod = model.ShippingMethod;
            entity.ShippingRateComputationMethodSystemName = model.ShippingRateComputationMethodSystemName;
            entity.ShippingStatusId = model.ShippingStatusId;
            entity.SubscriptionTransactionId = model.SubscriptionTransactionId;
            entity.TaxRates = model.TaxRates;
            entity.VatNumber = model.VatNumber;
            return entity;
        }

        public static Order MapToEntityWithEntity(OrderDTO model, Order entity)
        {
            entity.AffiliateId = model.AffiliateId;
            entity.AllowStoringCreditCardNumber = model.AllowStoringCreditCardNumber;
            entity.AuthorizationTransactionCode = model.AuthorizationTransactionCode;
            entity.AuthorizationTransactionId = model.AuthorizationTransactionId;
            entity.AuthorizationTransactionResult = model.AuthorizationTransactionResult;
            entity.BillingAddressId = model.BillingAddressId;
            entity.CaptureTransactionId = model.CaptureTransactionId;
            entity.CustomerId = model.CustomerId;
            entity.CustomOrderNumber = model.CustomOrderNumber;
            entity.CardCvv2 = model.CardCvv2;
            entity.CaptureTransactionResult = model.CaptureTransactionResult;
            entity.CardExpirationMonth = model.CardExpirationMonth;
            entity.CardExpirationYear = model.CardExpirationYear;
            entity.CardName = model.CardName;
            entity.CardNumber = model.CardNumber;
            entity.CardType = model.CardType;
            entity.CheckoutAttributeDescription = model.CheckoutAttributeDescription;
            entity.CheckoutAttributesXml = model.CheckoutAttributesXml;
            entity.CurrencyRate = model.CurrencyRate;
            entity.CustomerCurrencyCode = model.CustomerCurrencyCode;
            entity.CustomerIp = model.CustomerIp;
            entity.CustomerLanguageId = model.CustomerLanguageId;
            entity.CustomerTaxDisplayTypeId = model.CustomerTaxDisplayTypeId;
            entity.CustomValuesXml = model.CustomValuesXml;
            entity.MaskedCreditCardNumber = model.MaskedCreditCardNumber;
            entity.PickupAddressId = model.PickupAddressId;
            entity.PaymentMethodSystemName = model.PaymentMethodSystemName;
            entity.PaymentStatusId = model.PaymentStatusId;
            entity.PickupInStore = model.PickupInStore;
            entity.PaidDateUtc = model.PaidDateUtc;
            entity.PaymentMethodAdditionalFeeExclTax = model.PaymentMethodAdditionalFeeExclTax;
            entity.PaymentMethodAdditionalFeeInclTax = model.PaymentMethodAdditionalFeeInclTax;
            entity.OrderDiscount = model.OrderDiscount;
            entity.OrderGuid = model.OrderGuid;
            entity.OrderShippingExclTax = model.OrderShippingExclTax;
            entity.OrderShippingInclTax = model.OrderShippingInclTax;
            entity.OrderStatusId = model.OrderStatusId;
            entity.OrderSubTotalDiscountExclTax = model.OrderSubTotalDiscountExclTax;
            entity.OrderSubTotalDiscountInclTax = model.OrderSubTotalDiscountInclTax;
            entity.OrderSubtotalExclTax = model.OrderSubtotalExclTax;
            entity.OrderSubtotalInclTax = model.OrderSubtotalInclTax;
            entity.OrderTax = model.OrderTax;
            entity.OrderTotal = model.OrderTotal;
            entity.RedeemedRewardPointsEntryId = model.RedeemedRewardPointsEntryId;
            entity.RefundedAmount = model.RefundedAmount;
            entity.RewardPointsHistoryEntryId = model.RewardPointsHistoryEntryId;
            entity.ShippingAddressId = model.ShippingAddressId;
            entity.StoreId = model.StoreId;
            entity.ShippingMethod = model.ShippingMethod;
            entity.ShippingRateComputationMethodSystemName = model.ShippingRateComputationMethodSystemName;
            entity.ShippingStatusId = model.ShippingStatusId;
            entity.SubscriptionTransactionId = model.SubscriptionTransactionId;
            entity.TaxRates = model.TaxRates;
            entity.VatNumber = model.VatNumber;
            return entity;
        }

    }
}
