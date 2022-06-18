using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using TK.Data;
using TurrantKar.DTO;
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

        /// <inheritdoc />  
        public async Task<List<AddressDTO>> GetAddressListByCustomerId(int customerId, CancellationToken token = default(CancellationToken))
        {
            string sql = "prc_GetAddressListByCustomerId @CustomerId, @IsDeleted";
            SqlParameter paramDELETED = new SqlParameter("@IsDeleted", false);
            SqlParameter paramCustomerId = new SqlParameter("@CustomerId", customerId);
            return await GetQueryEntityListAsync<AddressDTO>(sql, new SqlParameter[] { paramCustomerId,paramDELETED }, token);
        }

        /// <inheritdoc />  
        public async Task<AddressDTO> GetAddressDetailById(int addressId, CancellationToken token = default(CancellationToken))
        {
            string sql = "prc_GetAddressByAddressId @AddressId , @IsDeleted";
            SqlParameter paramDeleted = new SqlParameter("@IsDeleted", false);
            SqlParameter paramAddressId = new SqlParameter("@AddressId", addressId);
            return await GetQueryEntityAsync<AddressDTO>(sql, new SqlParameter[] {  paramAddressId, paramDeleted }, token);
        }

    }
}
