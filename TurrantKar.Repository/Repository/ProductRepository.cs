using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Repository;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to Product and services related to it
    /// </summary>
    public class ProductRepository : BaseRepository<Product, TKDBContext>, IProductRepository
    {
        #region Constructor
        public ProductRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion

        #region Get
        /// <inheritdoc />  
        public async Task<List<ProductViewDTO>> GetProductList(bool showHomePage, CancellationToken token = default(CancellationToken))
        {
            string bindedString = null;
            string sql = @"SELECT p.[Id]
                                  , p.[CreatedOn]
                                  ,p.[CreatedBy]
                                  ,p.[ModifiedOn]
                                  ,p.[ModifiedBy]
                                  ,p.[IsDeleted]
                                  ,p.[TenantId]
                                  ,p.[Name]
                                  ,p.[ShortDescription]
                                  ,p.[FullDescription]
                                  ,p.[Price]
                                  ,p.[PricePerQuantity]
                                  ,p.[Offer]
                                  ,p.[ShowOnHomepage]
                                  ,p.[DeliveryInstruction]
                                  ,p.[IsFreeShipping]
                                  ,p.[IsInStock]
                                  ,p.[IsCODAvailable]
                                  ,p.[OnlySupportedPincode]
                                  ,p.[Tag]
                                  ,p.[StockQuantity]
	                              ,pc.SeoFilename AS FileName
	                              ,pc.VirtualPath AS ImageUrl 
                                  ,c.Name As CategoryName
								  ,c.Id As CategoryId
                              FROM [dbo].[Product] p
							  INNER JOIN ProductCategoryMapping pcm on pcm.ProductId = p.Id
							  INNER JOIN Category c on c.id = pcm.CategoryId
                              INNER JOIN ProductPictureMapping ppm on ppm.ProductId = p.Id
                              INNER JOIN Picture pc on ppm.PictureId = pc.PictureGuidId ";
            if (showHomePage)
            {
                bindedString = sql + "WHERE p.IsDeleted = @IsDeleted AND p.[ShowOnHomepage] = @ShowHomePage";
                SqlParameter paramDELETED = new SqlParameter("@IsDeleted", false);
                SqlParameter paramShowHomePage = new SqlParameter("@ShowHomePage", showHomePage);
                return await GetQueryEntityListAsync<ProductViewDTO>(bindedString, new SqlParameter[] { paramDELETED, paramShowHomePage }, token);
            }
            else
            {
                bindedString = sql + "WHERE p.IsDeleted = @IsDeleted";
                SqlParameter paramDELETED = new SqlParameter("@IsDeleted", false);
                return await GetQueryEntityListAsync<ProductViewDTO>(bindedString, new SqlParameter[] { paramDELETED }, token);
            }
           
        }

        /// <inheritdoc />  
        public async Task<ProductViewDTO> GetProductDetailById(int productId, CancellationToken token = default(CancellationToken))
        {
            string sql = @"SELECT p.[Id]
                                  , p.[CreatedOn]
                                  ,p.[CreatedBy]
                                  ,p.[ModifiedOn]
                                  ,p.[ModifiedBy]
                                  ,p.[IsDeleted]
                                  ,p.[TenantId]
                                  ,p.[Name]
                                  ,p.[ShortDescription]
                                  ,p.[FullDescription]
                                  ,p.[Price]
                                  ,p.[PricePerQuantity]
                                  ,p.[Offer]
                                  ,p.[ShowOnHomepage]
                                  ,p.[DeliveryInstruction]
                                  ,p.[IsFreeShipping]
                                  ,p.[IsInStock]
                                  ,p.[IsCODAvailable]
                                  ,p.[OnlySupportedPincode]
                                  ,p.[Tag]
                                  ,p.[StockQuantity]
	                             ,pc.SeoFilename AS FileName
	                              ,pc.VirtualPath AS ImageUrl 
                                  ,c.Name As CategoryName
								  ,c.Id As CategoryId
                              FROM [dbo].[Product] p
							  INNER JOIN ProductCategoryMapping pcm on pcm.ProductId = p.Id
							  INNER JOIN Category c on c.id = pcm.CategoryId
                              INNER JOIN ProductPictureMapping ppm on ppm.ProductId = p.Id
                              INNER JOIN Picture pc on ppm.PictureId = pc.PictureGuidId
                              WHERE p.IsDeleted = @IsDeleted AND p.Id = @ProductId";
            SqlParameter paramDeleted = new SqlParameter("@IsDeleted", false);
            SqlParameter paramProductId = new SqlParameter("@ProductId", productId);
            return await GetQueryEntityAsync<ProductViewDTO>(sql, new SqlParameter[] { paramProductId, paramDeleted }, token);
        }

        #endregion

    }
}

