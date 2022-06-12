using TK.Data;
using TurrantKar.Entity;
using TurrantKar.Repository;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of AddressDS
    /// </summary>
    public class AddressDS : BaseDS<Address>, IAddressDS
    {
        #region Local Member
        IAddressRepository _addressRepository;
        IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public AddressDS(IAddressRepository addressRepository, IUnitOfWork unitOfWork) : base(addressRepository)
        {
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
    }
}
