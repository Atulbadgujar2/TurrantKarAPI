using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.DS
{
    /// <summary>
    /// This class Contain Business Logic of Customer
    /// </summary>
    public interface ICustomerDS : IBaseDS<Customer>
    {
        Task<List<CustomerViewDTO>> GetCustomerList(CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> AddCustomerAsync(CustomerDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> UpdateCustomerAsync(CustomerDTO model, CancellationToken token = default(CancellationToken));

        Task<ResponseModelDTO> DeleteCustomerAsync(IdentificationDTO identificationDTO, CancellationToken token = default(CancellationToken));

    }
}

