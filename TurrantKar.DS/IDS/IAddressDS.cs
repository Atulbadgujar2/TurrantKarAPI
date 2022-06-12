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
        
        Task<ICollection<Address>> GetAddressByCustomerId(int customer, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> AddAddressAsync(AddressDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> UpdateAddressAsync(AddressDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> DeleteAddressAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken));


    }
}
