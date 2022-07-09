using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Data;
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
            string sql = "prc_GetCategoryByCategoryId @IsDeleted";
            SqlParameter paramDELETED = new SqlParameter("@IsDeleted", false);
            return await GetQueryEntityListAsync<CategoryViewDTO>(sql, new SqlParameter[] { paramDELETED }, token);
        }

        /// <inheritdoc />  
        public async Task<CategoryViewDTO> GetCategoryDetailById(int categoryId, CancellationToken token = default(CancellationToken))
        {
            string sql = "prc_GetCategoryByCategoryId @AddressId , @IsDeleted";
            SqlParameter paramDeleted = new SqlParameter("@IsDeleted", false);
            SqlParameter paramAddressId = new SqlParameter("@AddressId", categoryId);
            return await GetQueryEntityAsync<CategoryViewDTO>(sql, new SqlParameter[] { paramAddressId, paramDeleted }, token);
        }

        #endregion


    }
}
