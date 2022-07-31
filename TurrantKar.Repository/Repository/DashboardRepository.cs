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
            string sql = @"SELECT COUNT (p.[Id]) AS TotalProducts,
                    (SELECT COUNT(c.[Id]) FROM Category c WHERE p.IsDeleted = @IsDeleted) AS TotalCategories,
                    (SELECT COUNT(cu.[Id]) FROM Customer cu WHERE p.IsDeleted = @IsDeleted ) AS TotalUsers,
                    (SELECT COUNT(o.[Id]) FROM[Order] o WHERE p.IsDeleted = @IsDeleted ) AS TotalOrders
                    FROM[dbo].[Product] p
                    WHERE p.IsDeleted = @IsDeleted ";
            SqlParameter paramDeleted = new SqlParameter("@IsDeleted", false);
    
            return await GetQueryEntityAsync<DashboardDTO>(sql, new SqlParameter[] { paramDeleted }, token);
        } 
        #endregion
    }
}
