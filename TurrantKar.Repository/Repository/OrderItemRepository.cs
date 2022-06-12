using Microsoft.AspNetCore.Http;
using TK.Data;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to OrderItem and services related to it
    /// </summary>
    public class OrderItemRepository : BaseRepository<OrderItem, TKDBContext>, IOrderItemRepository
    {
        #region Constructor
        public OrderItemRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}
