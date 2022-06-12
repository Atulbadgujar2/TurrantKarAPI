using Microsoft.AspNetCore.Http;
using TK.Data;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to CategoryTemplate and services related to it
    /// </summary>
    public class CategoryTemplateRepository : BaseRepository<CategoryTemplate, TKDBContext>, ICategoryTemplateRepository
    {
        #region Constructor
        public CategoryTemplateRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}
