using TK.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of OrderNote
    /// </summary>
    public class OrderNoteDS : BaseDS<OrderNote>, IOrderNoteDS
    {
        #region Local Member
        IOrderNoteRepository _orderNoteRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public OrderNoteDS(IOrderNoteRepository orderNoteRepository, IUnitOfWork unitOfWork) : base(orderNoteRepository)
        {
            _orderNoteRepository = orderNoteRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}

