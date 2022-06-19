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
