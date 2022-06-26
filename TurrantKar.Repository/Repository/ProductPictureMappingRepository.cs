using Microsoft.AspNetCore.Http;
using TurrantKar.Data;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to ProductPictureMapping and services related to it
    /// </summary>
    public class ProductPictureMappingRepository : BaseRepository<ProductPictureMapping, TKDBContext>, IProductPictureMappingRepository
    {
        #region Constructor
        public ProductPictureMappingRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}
