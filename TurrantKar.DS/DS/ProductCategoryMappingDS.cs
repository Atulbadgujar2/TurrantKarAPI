using TurrantKar.Repository;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of ProductCategoryMapping
    /// </summary>
    public class ProductCategoryMappingDS : BaseDS<ProductCategoryMapping>, IProductCategoryMappingDS
    {
        #region Local Member
        IProductCategoryMappingRepository _productCategoryMappingRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ProductCategoryMappingDS(IProductCategoryMappingRepository productCategoryMappingRepository, IUnitOfWork unitOfWork) : base(productCategoryMappingRepository)
        {
            _productCategoryMappingRepository = productCategoryMappingRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
