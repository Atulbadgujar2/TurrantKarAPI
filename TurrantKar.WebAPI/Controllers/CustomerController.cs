using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DS;
using TurrantKar.DTO;

namespace TurrantKar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Local Member
        ICustomerDS _customerDS;
        #endregion

        #region Contructor
        public CustomerController(ICustomerDS customerDS)
        {
            _customerDS = customerDS;
        }
        #endregion

        #region MyRegion
        [HttpGet]
        [Route("list")]
        public async Task<List<CustomerViewDTO>> GetCustomerList(CancellationToken token = default(CancellationToken))
        {
            return await _customerDS.GetCustomerList(token);
        }
        #endregion
    }
}
