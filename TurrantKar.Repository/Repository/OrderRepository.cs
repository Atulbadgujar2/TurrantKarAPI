using Microsoft.AspNetCore.Http;
using TurrantKar.Repository;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to Order and services related to it
    /// </summary>
    public class OrderRepository : BaseRepository<Order, TKDBContext>, IOrderRepository
    {
        #region Constructor
        public OrderRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}

