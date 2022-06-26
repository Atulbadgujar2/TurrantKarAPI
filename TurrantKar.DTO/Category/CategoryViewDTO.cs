namespace TurrantKar.DTO
{
    public class CategoryViewDTO : BaseDTO
    {
        public string Name { get; set; }

        public string ImageUrl  { get; set; }
        public string Description { get; set; }

        public bool ShowOnHomepage { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public decimal Discount { get; set; }

        public string FileName { get; set; }


    }
}
