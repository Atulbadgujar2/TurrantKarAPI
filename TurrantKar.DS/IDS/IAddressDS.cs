using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Address
    /// </summary>
    public interface IAddressDS : IBaseDS<Address>
    {
        
        Task<List<AddressDTO>> GetAddressListByCustomerId(int customerId, CancellationToken token = default(CancellationToken));

        Task<AddressDTO> GetAddressDetailById(int addressId, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> AddAddressAsync(AddressDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> UpdateAddressAsync(AddressDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> DeleteAddressAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken));

       

    }
}
