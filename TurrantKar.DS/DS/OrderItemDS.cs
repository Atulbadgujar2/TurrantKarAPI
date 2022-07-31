using TurrantKar.Repository;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of OrderItem
    /// </summary>
    public class OrderItemDS : BaseDS<OrderItem>, IOrderItemDS
    {
        #region Local Member
        IOrderItemRepository _orderItemRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public OrderItemDS(IOrderItemRepository orderItemRepository, IUnitOfWork unitOfWork) : base(orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
