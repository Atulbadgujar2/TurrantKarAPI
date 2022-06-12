using Microsoft.AspNetCore.Http;
using TK.Data;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to ProductCategoryMapping and services related to it
    /// </summary>
    public class ProductCategoryMappingRepository : BaseRepository<Picture, TKDBContext>, IPictureRepository
    {
        #region Constructor
        public ProductCategoryMappingRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}
