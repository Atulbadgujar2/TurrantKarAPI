using TK.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Order
    /// </summary>
    public class OrderDS : BaseDS<Order>, IOrderDS
    {
        #region Local Member
        IOrderRepository _orderRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public OrderDS(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}

