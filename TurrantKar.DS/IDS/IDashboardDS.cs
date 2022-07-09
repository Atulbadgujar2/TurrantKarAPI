using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DTO;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Dashboard
    /// </summary>
    public interface IDashboardDS : IBaseDS<DashboardDTO>
    {

        Task<DashboardDTO> GetDashboardDetail(CancellationToken token = default(CancellationToken));
    }
}
