using Microsoft.AspNetCore.Http;
using TurrantKar.Repository;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to Picture and services related to it
    /// </summary>
    public class PictureRepository : BaseRepository<Picture, TKDBContext>, IPictureRepository
    {
        #region Constructor
        public PictureRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}