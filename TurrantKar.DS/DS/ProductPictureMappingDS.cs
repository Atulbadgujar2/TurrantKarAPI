using TurrantKar.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of ProductPictureMapping
    /// </summary>
    public class ProductPictureMappingDS : BaseDS<ProductPictureMapping>, IProductPictureMappingDS
    {
        #region Local Member
        IProductPictureMappingRepository _ProductPictureMappingRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ProductPictureMappingDS(IProductPictureMappingRepository ProductPictureMappingRepository, IUnitOfWork unitOfWork) : base(ProductPictureMappingRepository)
        {
            _ProductPictureMappingRepository = ProductPictureMappingRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}

