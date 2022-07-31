using Microsoft.AspNetCore.Http;
using TurrantKar.Repository;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to ProductTemplate and services related to it
    /// </summary>
    public class ProductTemplateRepository : BaseRepository<ProductTemplate, TKDBContext>, IProductTemplateRepository
    {
        #region Constructor
        public ProductTemplateRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}

