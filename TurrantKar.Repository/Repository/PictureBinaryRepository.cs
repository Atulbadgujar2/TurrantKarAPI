using Microsoft.AspNetCore.Http;
using TurrantKar.Data;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to PictureBinary and services related to it
    /// </summary>
    public class PictureBinaryRepository : BaseRepository<PictureBinary, TKDBContext>, IPictureBinaryRepository
    {
        #region Constructor
        public PictureBinaryRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}

