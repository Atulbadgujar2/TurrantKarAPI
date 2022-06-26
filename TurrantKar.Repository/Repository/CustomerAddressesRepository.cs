﻿using Microsoft.AspNetCore.Http;
using TurrantKar.Data;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to CategoryTemplate and services related to it
    /// </summary>
    public class CustomerAddressesRepository : BaseRepository<CustomerAddresses, TKDBContext>, ICustomerAddressesRepository
    {
        #region Constructor
        public CustomerAddressesRepository(TKDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
        #endregion
    }
}

