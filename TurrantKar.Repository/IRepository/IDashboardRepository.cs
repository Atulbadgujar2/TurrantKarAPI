using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Repository;
using TurrantKar.DTO;

namespace TurrantKar.Repository
{
    /// <summary>
    /// This is the repository responsible for filtering data realted to DashboardDTO and services related to it
    /// </summary>
    public interface IDashboardRepository : IBaseRepository<DashboardDTO>
    {

        Task<DashboardDTO> GetDashboardDetail(CancellationToken token = default(CancellationToken));
    }
}
