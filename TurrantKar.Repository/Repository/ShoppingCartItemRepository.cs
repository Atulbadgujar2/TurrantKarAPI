using Microsoft.AspNetCore.Http;
using TK.Data;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to ShoppingCartItem and services related to it
    /// </summary>
    public class ShoppingCartItemRepository : BaseRepository<ShoppingCartItem, TKDBContext>, IShoppingCartItemRepository
    {
        #region Constructor
        public ShoppingCartItemRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}

