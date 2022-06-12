using TK.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Category
    /// </summary>
    public class CategoryDS : BaseDS<Category>, ICategoryDS
    {
        #region Local Member
        ICategoryRepository _categoryRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CategoryDS(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
