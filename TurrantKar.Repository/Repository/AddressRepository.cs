using Microsoft.AspNetCore.Http;
using TK.Data;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to Address and services related to it
    /// </summary>
    public class AddressRepository : BaseRepository<Address, TKDBContext>, IAddressRepository
    {
        #region Constructor
        public AddressRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}
