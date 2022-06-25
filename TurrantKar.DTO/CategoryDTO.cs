using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurrantKar.Entity;

namespace TurrantKar.DTO
{
    public class CategoryDTO : BaseDTO
    {
        public string Name { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaTitle { get; set; }
        public string PageSizeOptions { get; set; }
        public string Description { get; set; }
        public int? CategoryTemplateId { get; set; }
        public string MetaDescription { get; set; }
        public int? ParentCategoryId { get; set; }
        
        public int PageSize { get; set; }
        public bool AllowCustomersToSelectPageSize { get; set; }
        public bool ShowOnHomepage { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public bool SubjectToAcl { get; set; }
        public bool LimitedToStores { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public bool PriceRangeFiltering { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public bool ManuallyPriceRange { get; set; }

        //public IFormFile FileUpload { get; set; }

        public static Category MapToEntity(CategoryDTO model)
        {
            Category entity = new Category();           
            entity.AllowCustomersToSelectPageSize = model.AllowCustomersToSelectPageSize;
            entity.CategoryTemplateId = model.CategoryTemplateId;
            entity.Description = model.Description;
            entity.DisplayOrder = model.DisplayOrder;
            entity.IncludeInTopMenu = model.IncludeInTopMenu;
            entity.LimitedToStores = model.LimitedToStores;
            entity.ManuallyPriceRange = model.ManuallyPriceRange;
            entity.PriceTo = model.PriceTo;
            entity.PageSizeOptions = model.PageSizeOptions;
            entity.Published = model.Published;
            entity.PriceFrom = model.PriceFrom;
            entity.PageSize = model.PageSize;
            entity.ParentCategoryId = model.ParentCategoryId;
            entity.PriceRangeFiltering = model.PriceRangeFiltering;
            entity.MetaKeywords = model.MetaKeywords;
            entity.Name = model.Name;
            entity.MetaTitle = model.MetaTitle;
            entity.ShowOnHomepage = model.ShowOnHomepage;
            return entity;
        }
    }

}
