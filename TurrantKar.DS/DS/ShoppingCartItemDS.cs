using TurrantKar.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of ShoppingCartItem
    /// </summary>
    public class ShoppingCartItemDS : BaseDS<ShoppingCartItem>, IShoppingCartItemDS
    {
        #region Local Member
        IShoppingCartItemRepository _shoppingCartItemRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ShoppingCartItemDS(IShoppingCartItemRepository shoppingCartItemRepository, IUnitOfWork unitOfWork) : base(shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
