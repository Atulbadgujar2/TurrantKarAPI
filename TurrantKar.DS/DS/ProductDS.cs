using TK.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Product
    /// </summary>
    public class ProductDS : BaseDS<Product>, IProductDS
    {
        #region Local Member
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ProductDS(IProductRepository productRepository, IUnitOfWork unitOfWork) : base(productRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
