using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Data;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to CustomerRepository and services related to it
    /// </summary>
    public class CustomerRepository : BaseRepository<Customer, TKDBContext>, ICustomerRepository
    {
        #region Constructor
        public CustomerRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion

        /// <inheritdoc />  
        public async Task<List<CustomerViewDTO>> GetCustomerList(CancellationToken token = default(CancellationToken))
        {
            string sql = "prc_GetCustomerList @IsDeleted";
            SqlParameter paramDELETED = new SqlParameter("@IsDeleted", false);
            return await GetQueryEntityListAsync<CustomerViewDTO>(sql, new SqlParameter[] { paramDELETED }, token);
        }
    }
}
