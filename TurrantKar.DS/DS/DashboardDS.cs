using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Repository;
using TurrantKar.DTO;
using TurrantKar.Repository;

namespace TurrantKar.DS
{

    /// <summary>
    /// This class Contain Business Logic of DashboardDTO
    /// </summary>
    public class DashboardDS : BaseDS<DashboardDTO>, IDashboardDS
    {
        #region Local Member
        IDashboardRepository _dashboardRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public DashboardDS(IDashboardRepository dashboardRepository, IUnitOfWork unitOfWork) : base(dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Get
        /// <inheritdoc />  
        public async Task<DashboardDTO> GetDashboardDetail(CancellationToken token = default(CancellationToken))
        {
            return await _dashboardRepository.GetDashboardDetail( token);
        } 
        #endregion
    }
}
