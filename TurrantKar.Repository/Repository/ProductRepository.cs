using Microsoft.AspNetCore.Http;
using TurrantKar.Data;
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
    }
}

