using TK.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of CategoryTemplate
    /// </summary>
    public class CategoryTemplateDS : BaseDS<CategoryTemplate>, ICategoryTemplateDS
    {
        #region Local Member
        ICategoryTemplateRepository _categoryTemplateRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CategoryTemplateDS(ICategoryTemplateRepository categoryTemplateRepository, IUnitOfWork unitOfWork) : base(categoryTemplateRepository)
        {
            _categoryTemplateRepository = categoryTemplateRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
