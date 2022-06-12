
using TK.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Customer
    /// </summary>
    public class CustomerDS : BaseDS<Customer>, ICustomerDS
    {
        #region Local Member
        ICustomerRepository _customerRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CustomerDS(ICustomerRepository customerRepository, IUnitOfWork unitOfWork) : base(customerRepository)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
