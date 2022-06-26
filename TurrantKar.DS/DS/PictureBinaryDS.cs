using TurrantKar.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of PictureBinary
    /// </summary>
    public class PictureBinaryDS : BaseDS<PictureBinary>, IPictureBinaryDS
    {
        #region Local Member
        IPictureBinaryRepository _pictureBinaryRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public PictureBinaryDS(IPictureBinaryRepository pictureBinaryRepository, IUnitOfWork unitOfWork) : base(pictureBinaryRepository)
        {
            _pictureBinaryRepository = pictureBinaryRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}