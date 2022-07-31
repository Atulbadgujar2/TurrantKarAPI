﻿using Microsoft.AspNetCore.Http;
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
    /// This is the repository responsible for filtering data realted to Category and services related to it
    /// </summary>
    public class CategoryRepository : BaseRepository<Category, TKDBContext>, ICategoryRepository
    {
        #region Constructor
        public CategoryRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        { }
        #endregion

        #region Get
        /// <inheritdoc />  
        public async Task<List<CategoryViewDTO>> GetCategoryList(CancellationToken token = default(CancellationToken))
        {
            string sql = @"SELECT c.[Id]
                                  , c.[CreatedOn]
                                  ,c.[CreatedBy]
                                  ,c.[ModifiedOn]
                                  ,c.[ModifiedBy]
                                  ,c.[IsDeleted]
                                  ,c.[TenantId]
                                  ,c.[Name]
                                  ,c.[Description]
                                  ,c.[ShowOnHomepage]
                                  ,c.[IncludeInTopMenu]
                                  ,c.[Discount]
	                              ,p.SeoFilename AS FileName
	                              ,p.VirtualPath AS ImageUrl
                              FROM [dbo].[Category] c
                              INNER JOIN CategoryPictureMapping cpm on cpm.CategoryId = c.Id
                              INNER JOIN Picture p on cpm.PictureId = p.PictureGuidId
                              WHERE c.IsDeleted = @IsDeleted ";
            SqlParameter paramDELETED = new SqlParameter("@IsDeleted", false);
            return await GetQueryEntityListAsync<CategoryViewDTO>(sql, new SqlParameter[] { paramDELETED }, token);
        }

        /// <inheritdoc />  
        public async Task<CategoryViewDTO> GetCategoryDetailById(int categoryId, CancellationToken token = default(CancellationToken))
        {
            string sql = @"SELECT c.[Id]
                                  , c.[CreatedOn]
                                  ,c.[CreatedBy]
                                  ,c.[ModifiedOn]
                                  ,c.[ModifiedBy]
                                  ,c.[IsDeleted]
                                  ,c.[TenantId]
                                  ,c.[Name]
                                  ,c.[Description]
                                  ,c.[ShowOnHomepage]
                                  ,c.[IncludeInTopMenu]
                                  ,c.[Discount]
	                              ,p.SeoFilename AS FileName
	                              ,p.VirtualPath AS ImageUrl
                              FROM [dbo].[Category] c
                              INNER JOIN CategoryPictureMapping cpm on cpm.CategoryId = c.Id
                              INNER JOIN Picture p on cpm.PictureId = p.PictureGuidId
                              WHERE c.IsDeleted = @IsDeleted AND c.Id = @CategoryId";
            SqlParameter paramDeleted = new SqlParameter("@IsDeleted", false);
            SqlParameter paramAddressId = new SqlParameter("@CategoryId", categoryId);
            return await GetQueryEntityAsync<CategoryViewDTO>(sql, new SqlParameter[] { paramAddressId, paramDeleted }, token);
        }

        #endregion


    }
}
