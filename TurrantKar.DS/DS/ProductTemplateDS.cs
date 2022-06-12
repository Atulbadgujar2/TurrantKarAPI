using TK.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of ProductTemplate
    /// </summary>
    public class ProductTemplateDS : BaseDS<ProductTemplate>, IProductTemplateDS
    {
        #region Local Member
        IProductTemplateRepository _productTemplateRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ProductTemplateDS(IProductTemplateRepository productTemplateRepository, IUnitOfWork unitOfWork) : base(productTemplateRepository)
        {
            _productTemplateRepository = productTemplateRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}

