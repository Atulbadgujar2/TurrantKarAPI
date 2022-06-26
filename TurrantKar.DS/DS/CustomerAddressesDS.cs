using TurrantKar.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of CustomerAddresses
    /// </summary>
    public class CustomerAddressesDS : BaseDS<CustomerAddresses>, ICustomerAddressesDS
    {
        #region Local Member
        ICustomerAddressesRepository _customerAddressesRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CustomerAddressesDS(ICustomerAddressesRepository customerAddressesRepository, IUnitOfWork unitOfWork) : base(customerAddressesRepository)
        {
            _customerAddressesRepository = customerAddressesRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
