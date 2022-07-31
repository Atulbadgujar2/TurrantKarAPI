using Microsoft.AspNetCore.Http;
using TurrantKar.Repository;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to ShoppingCartItem and services related to it
    /// </summary>
    public class ShoppingCartRepository : BaseRepository<ShoppingCart, TKDBContext>, IShoppingCartRepository
    {
        #region Constructor
        public ShoppingCartRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}

