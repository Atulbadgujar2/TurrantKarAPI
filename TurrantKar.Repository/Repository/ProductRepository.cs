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
        public async Task<List<ProductViewDTO>> GetProductList(CancellationToken token = default(CancellationToken))
        {
            string sql = "prc_GetProductByProductId @IsDeleted";
            SqlParameter paramDELETED = new SqlParameter("@IsDeleted", false);
            return await GetQueryEntityListAsync<ProductViewDTO>(sql, new SqlParameter[] { paramDELETED }, token);
        }

        /// <inheritdoc />  
        public async Task<ProductViewDTO> GetProductDetailById(int productId, CancellationToken token = default(CancellationToken))
        {
            string sql = "prc_GetProductByProductId @ProductId , @IsDeleted";
            SqlParameter paramDeleted = new SqlParameter("@IsDeleted", false);
            SqlParameter paramProductId = new SqlParameter("@ProductId", productId);
            return await GetQueryEntityAsync<ProductViewDTO>(sql, new SqlParameter[] { paramProductId, paramDeleted }, token);
        }

        #endregion

    }
}

