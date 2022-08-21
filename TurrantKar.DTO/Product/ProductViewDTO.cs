namespace TurrantKar.DTO
{
    public class ProductViewDTO : BaseDTO
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }

        public decimal Price { get; set; }

        public decimal PricePerQuantity { get; set; }

        public decimal Offer { get; set; }

        public bool ShowOnHomepage { get; set; }

        public string DeliveryInstruction { get; set; }

        public bool IsFreeShipping { get; set; }

        public bool IsInStock { get; set; }

        public bool IsCODAvailable { get; set; }

        public int OnlySupportedPincode { get; set; }

        public string Tag { get; set; }

        public int StockQuantity { get; set; }

        public string ImageUrl { get; set; }

        public string FileName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
