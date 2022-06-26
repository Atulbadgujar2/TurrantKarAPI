using Microsoft.AspNetCore.Http;
using TurrantKar.Data;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to CategoryPictureMapping and services related to it
    /// </summary>
    public class CategoryPictureMappingRepository : BaseRepository<CategoryPictureMapping, TKDBContext>, ICategoryPictureMappingRepository
    {
        #region Constructor
        public CategoryPictureMappingRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}

