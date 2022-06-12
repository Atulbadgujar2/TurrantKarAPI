using TK.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of ReturnRequest
    /// </summary>
    public class ReturnRequestDS : BaseDS<ReturnRequest>, IReturnRequestDS
    {
        #region Local Member
        IReturnRequestRepository _returnRequestRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ReturnRequestDS(IReturnRequestRepository returnRequestRepository, IUnitOfWork unitOfWork) : base(returnRequestRepository)
        {
            _returnRequestRepository = returnRequestRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
