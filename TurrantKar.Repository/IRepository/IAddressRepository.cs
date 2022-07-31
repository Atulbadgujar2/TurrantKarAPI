using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Repository;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{

    /// <summary>
    /// This is the repository responsible for filtering data realted to Address and services related to it
    /// </summary>
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<List<AddressDTO>> GetAddressListByCustomerId(int customerId, CancellationToken token = default(CancellationToken));

        Task<AddressDTO> GetAddressDetailById(int AddressId, CancellationToken token = default(CancellationToken));
    }
}
