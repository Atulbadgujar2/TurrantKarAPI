﻿
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace TurrantKar.Entity
{

    /// <summary>
    /// this entity represting all Customer properties.
    /// </summary>
    [Table("Customer")]
    public class Customer : BaseEntity
    {
      public string Username{get;set;}
      public string Email{get;set;}
      public string EmailToRevalidate{get;set;}
      public string SystemName{get;set;}
      public int? BillingAddressId{get;set;}
      public int? ShippingAddressId{get;set;}
      public Guid CustomerGuid{get;set;}
      public string AdminComment{get;set;}
      public bool IsTaxExempt{get;set;}
      public int AffiliateId{get;set;}
      public int VendorId{get;set;}
      public bool HasShoppingCartItems{get;set;}
      public bool RequireReLogin{get;set;}
      public int FailedLoginAttempts{get;set;}
      public DateTime? CannotLoginUntilDateUtc{get;set;}
      public bool Active{get;set;}
      public bool IsSystemAccount{get;set;}
      public string LastIpAddress{get;set;}     
      public DateTime? LastLoginDateUtc{get;set;}
      public DateTime LastActivityDateUtc {get;set;}
      public int RegisteredInStoreId{get;set;}

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string Gender { get; set; }

    }
}

