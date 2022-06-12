using TK.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Picture
    /// </summary>
    public class PictureDS : BaseDS<Picture>, IPictureDS
    {
        #region Local Member
        IPictureRepository _pictureRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public PictureDS(IPictureRepository pictureRepository, IUnitOfWork unitOfWork) : base(pictureRepository)
        {
            _pictureRepository = pictureRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}