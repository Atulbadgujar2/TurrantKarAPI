using Microsoft.AspNetCore.Http;
using TK.Data;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to OrderNote and services related to it
    /// </summary>
    public class OrderNoteRepository : BaseRepository<OrderNote, TKDBContext>, IOrderNoteRepository
    {
        #region Constructor
        public OrderNoteRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}
