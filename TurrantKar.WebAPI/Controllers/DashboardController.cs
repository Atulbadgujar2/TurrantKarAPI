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
    public class DashboardController : ControllerBase
    {

        #region Local Member
        IDashboardDS _dashboardDS;
        #endregion

        #region Contructor
        public DashboardController(IDashboardDS dashboardDS)
        {
            _dashboardDS = dashboardDS;
        }
        #endregion

        [HttpGet]
        [Route("home")]
        public async Task<DashboardDTO> GetCategoryDetailById(CancellationToken token = default(CancellationToken))
        {
            return await _dashboardDS.GetDashboardDetail(token);
        }
    }
}
