using Microsoft.AspNetCore.Http;
using TK.Data;
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
        {

        }
        #endregion
    }
}
