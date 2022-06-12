﻿using Microsoft.AspNetCore.Http;
using TK.Data;
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
    }
}
