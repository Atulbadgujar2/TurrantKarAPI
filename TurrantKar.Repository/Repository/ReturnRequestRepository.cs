using Microsoft.AspNetCore.Http;
using TurrantKar.Repository;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to ReturnRequest and services related to it
    /// </summary>
    public class ReturnRequestRepository : BaseRepository<ReturnRequest, TKDBContext>, IReturnRequestRepository
    {
        #region Constructor
        public ReturnRequestRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}

