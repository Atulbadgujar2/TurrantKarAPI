using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Repository;
using TurrantKar.DTO;

namespace TurrantKar.Repository
{

    /// <summary>
    /// This is the repository responsible for filtering data realted to Dashboard and services related to it
    /// </summary>
    public class DashboardRepository : BaseRepository<DashboardDTO, TKDBContext>, IDashboardRepository
    {
        #region Constructor
        public DashboardRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion


        #region Get
        /// <inheritdoc />  
        public async Task<DashboardDTO> GetDashboardDetail(CancellationToken token = default(CancellationToken))
        {
            string sql = "[prc_GetDashboardData] @IsDeleted";
            SqlParameter paramDeleted = new SqlParameter("@IsDeleted", false);
    
            return await GetQueryEntityAsync<DashboardDTO>(sql, new SqlParameter[] { paramDeleted }, token);
        } 
        #endregion
    }
}
