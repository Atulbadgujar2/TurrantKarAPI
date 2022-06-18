using Microsoft.AspNetCore.Http;
using TK.Data;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to ProductCategoryMapping and services related to it
    /// </summary>
    public class ProductCategoryMappingRepository : BaseRepository<ProductCategoryMapping, TKDBContext>, IProductCategoryMappingRepository
    {
        #region Constructor
        public ProductCategoryMappingRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}
