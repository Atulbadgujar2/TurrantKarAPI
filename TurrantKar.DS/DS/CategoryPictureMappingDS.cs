using TK.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of CategoryPictureMapping
    /// </summary>
    public class CategoryPictureMappingDS : BaseDS<CategoryPictureMapping>, ICategoryPictureMappingDS
    {
        #region Local Member
        ICategoryPictureMappingRepository _categoryPictureMappingRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CategoryPictureMappingDS(ICategoryPictureMappingRepository categoryPictureMappingRepository, IUnitOfWork unitOfWork) : base(categoryPictureMappingRepository)
        {
            _categoryPictureMappingRepository = categoryPictureMappingRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
