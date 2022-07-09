using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TurrantKar.Data;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{

    /// <summary>
    /// This is the repository responsible for filtering data realted to Customer and services related to it
    /// </summary>
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<List<CustomerViewDTO>> GetCustomerList(CancellationToken token = default(CancellationToken));
    }
}
